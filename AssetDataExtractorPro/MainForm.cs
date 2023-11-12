using AssetDataExtractorPro.InfoGMS2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace AssetDataExtractorPro
{
    public partial class MainForm : Form
    {
        private ProjectYYP _projectYYP;
        private RoomYY _roomYY;
        private string _projectPath;
        private string _projectFilePath;
        private BindingList<RoomYY> _rooms = new BindingList<RoomYY>();
        private BindingList<Layer> _layers = new BindingList<Layer>();
        private DataGenerationFormatting _dataGenerationFormatting;

        public MainForm()
        {
            InitializeComponent();
            UpdateRecentlyOpenedFilesMenu();
            roomslb.DataSource = _rooms;
            layerslb.DataSource = _layers;

            CultureInfo customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;

            LoadGMSProjects();
            _dataGenerationFormatting = new DataGenerationFormatting(dataFormatGV);
            dataFormatGV.MultiSelect = false;
            dataFormatGV.RowValidated += DataFormatGV_RowValidated;
            dataFormatGV.RowsAdded += DataFormatGV_RowsAdded;
            dataFormatGV.CellValueChanged += DataFormatGV_CellValueChanged;
            dataFormatGV.CellClick += DataFormatGV_CellValueChanged;
        }

        private void DataFormatGV_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            RefreshResultFormatting();
        }

        private void DataFormatGV_RowsAdded(object? sender, DataGridViewRowsAddedEventArgs e)
        {
            RefreshResultFormatting();
        }

        private void DataFormatGV_RowValidated(object? sender, DataGridViewCellEventArgs e)
        {
            RefreshResultFormatting();
        }

        private void LoadGMSProjects()
        {
            projectTSM.DropDownItems.Clear();
            var pathGMS2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GameMakerStudio2");
            var directoryUser = Directory.GetDirectories(pathGMS2).OrderByDescending(directory => Directory.GetLastWriteTime(directory)).FirstOrDefault();

            if (directoryUser != null)
            {
                var recentProjectsPathFile = Path.Combine(directoryUser, "recent_projects");
                var recentProjects = File.ReadAllLines(recentProjectsPathFile);
                projectTSM.DropDownItems.AddRange(recentProjects.Select(project => new ToolStripMenuItem(project, null, (sender, e) => ReadProjectFile(project))).ToArray());
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                ReadProjectFile(file);
                break;
            }
        }

        private void ClearLoadedInfo()
        {
            _projectYYP = null;
            _roomYY = null;
            _projectPath = null;
            _projectFilePath = null;
            _rooms.Clear();
            _layers.Clear();
        }

        public void ReadProjectFile(string filePath)
        {
            ClearLoadedInfo();

            try
            {
                var json = File.ReadAllText(filePath);
                if (json != null)
                {
                    switch (Path.GetExtension(filePath))
                    {
                        case ".yyp":
                            _projectFilePath = filePath;
                            _projectPath = Path.GetDirectoryName(filePath);
                            _projectYYP = JsonConvert.DeserializeObject<ProjectYYP>(json);
                            if (_projectYYP != null)
                            {
                                var recentlyOpenedFiles = Properties.Settings.Default.recentlyOpenedFiles;
                                if (recentlyOpenedFiles != null && !recentlyOpenedFiles.Contains(_projectFilePath))
                                {
                                    recentlyOpenedFiles.Add(_projectFilePath);
                                    Properties.Settings.Default.Save();
                                }

                                foreach (var roomID in _projectYYP.RoomOrderNodes)
                                {
                                    var jsonRoom = File.ReadAllText(Path.Combine(_projectPath, roomID.roomId.path));
                                    if (jsonRoom != null)
                                    {
                                        var room = JsonConvert.DeserializeObject<RoomYY>(jsonRoom);
                                        if (room != null)
                                        {
                                            _rooms.Add(room);
                                        }
                                    }
                                }
                            }
                            break;

                        case ".yy":
                            _projectFilePath = filePath;
                            _roomYY = JsonConvert.DeserializeObject<RoomYY>(json);

                            if (_roomYY != null)
                            {

                                var recentlyOpenedFiles = Properties.Settings.Default.recentlyOpenedFiles;
                                if (recentlyOpenedFiles != null && !recentlyOpenedFiles.Contains(_projectFilePath))
                                {
                                    recentlyOpenedFiles.Add(_projectFilePath);
                                    Properties.Settings.Default.Save();
                                }

                                foreach (var layer in _roomYY.layers)
                                {
                                    _layers.Add(layer);
                                }
                            }
                            break;
                    }
                }

                UpdateRecentlyOpenedFilesMenu();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                ClearLoadedInfo();
            }
        }

        private void roomslb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var room = (RoomYY)roomslb.SelectedItem;
            if (room != null)
            {
                _layers.Clear();
                foreach (var layer in room.layers)
                {
                    _layers.Add(layer);
                }
            }
        }

        private void layerslb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshResultFormatting();
        }

        private void RefreshResultFormatting()
        {
            dataFormatGV.BeginInvoke(new MethodInvoker(() =>
            {
                _dataGenerationFormatting.SaveDataFormatting();
                var dataFormatting = _dataGenerationFormatting.Data;
                var layer = (Layer)layerslb.SelectedItem;

                resultFormattingTB.Text = GenerateLayersData(layer, dataFormatting);
            }));
        }

        public string GenerateLayersData(Layer layer, BindingList<FormattingTextEntry> formattingTextEntries, int childIteration = 1, (float? shiftX, float? shiftY)? shift = null)
        {
            var shiftValue = shift ?? (0.0f, 0.0f);
            var nextShiftValue = (shiftValue.shiftX, shiftValue.shiftY);
            var assetIterator = 0;

            string startTabulation = new string('\t', childIteration - 1);
            string tabulation = new string('\t', childIteration);

            StringBuilder stringBuilder = new StringBuilder(startTabulation + "[\r\n");

            if (layer != null && layer.assets != null)
            {
                foreach (Asset asset in layer.assets)
                {
                    stringBuilder.Append(tabulation);

                    foreach (FormattingTextEntry formatting in formattingTextEntries)
                    {
                        if (formatting.IsComboBoxEnabled)
                        {
                            var propertyName = formatting.Text;
                            var propertyValue = PropertyAccess.GetNestedPropertyValue(asset, propertyName).ToString();

                            try
                            {
                                if (assetIterator == 0)
                                {
                                    switch (propertyName)
                                    {
                                        case "x":
                                            nextShiftValue.shiftX = (float.Parse(propertyValue) + shiftValue.shiftX);
                                            break;
                                        case "y":
                                            nextShiftValue.shiftY = (float.Parse(propertyValue) + shiftValue.shiftY);
                                            break;
                                    }
                                }

                                switch (propertyName)
                                {
                                    case "x":
                                        propertyValue = (float.Parse(propertyValue) - shiftValue.shiftX).ToString();
                                        break;
                                    case "y":
                                        propertyValue = (float.Parse(propertyValue) - shiftValue.shiftY).ToString();
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                propertyValue = PropertyAccess.GetNestedPropertyValue(asset, propertyName).ToString();
                                Debug.WriteLine(e);
                            }

                            stringBuilder.Append(propertyValue);
                        }
                        else
                        {
                            stringBuilder.Append(formatting.Text);
                        }
                    }

                    stringBuilder.Append("\r\n");
                    assetIterator++;
                }

                foreach (var obj in layer.layers)
                {
                    if (obj is JObject jObject)
                    {
                        Layer childLayer = jObject.ToObject<Layer>();
                        if (childLayer != null)
                        {
                            stringBuilder.Append(GenerateLayersData(childLayer, formattingTextEntries, childIteration + 1, nextShiftValue));
                        }
                    }
                    else if (obj is Layer childLayer)
                    {
                        stringBuilder.Append(GenerateLayersData(childLayer, formattingTextEntries, childIteration + 1, nextShiftValue));
                    }
                }

                stringBuilder.AppendLine(startTabulation + "],");
            }

            return stringBuilder.ToString();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_projectFilePath))
            {
                var selectedIndexRoom = roomslb.SelectedIndex;
                var selectedIndexLayer = layerslb.SelectedIndex;

                ReadProjectFile(_projectFilePath);

                RestoreSelectedIndex(roomslb, selectedIndexRoom);
                RestoreSelectedIndex(layerslb, selectedIndexLayer);
            }
        }

        private void RestoreSelectedIndex(ListBox listBox, int selectedIndex)
        {
            if (selectedIndex >= 0 && selectedIndex < listBox.Items.Count)
            {
                if (selectedIndex == 0 && listBox.Items.Count >= 1) listBox.SelectedIndex = 1;
                listBox.SelectedIndex = selectedIndex;
            }
        }

        private void addElementFormatting_Click(object sender, EventArgs e)
        {
            _dataGenerationFormatting.Data.Add(new FormattingTextEntry(", ", false));
        }

        private void MoveItem(int direction)
        {
            var bindingList = _dataGenerationFormatting.Data;
            int rowIndex = dataFormatGV.CurrentCell.RowIndex;
            int newRowIndex = rowIndex + direction;

            if (newRowIndex >= 0 && newRowIndex < bindingList.Count)
            {
                FormattingTextEntry item = bindingList[rowIndex];
                bindingList.RemoveAt(rowIndex);
                bindingList.Insert(newRowIndex, item);

                dataFormatGV.CurrentCell = dataFormatGV.Rows[newRowIndex].Cells[dataFormatGV.CurrentCell.ColumnIndex];
                dataFormatGV.Rows[newRowIndex].Selected = true;
            }
        }

        private void deleteFormattingDataBtn_Click(object sender, EventArgs e)
        {
            if (dataFormatGV.SelectedCells.Count > 0)
            {
                _dataGenerationFormatting.Data.RemoveAt(dataFormatGV.SelectedCells[0].RowIndex);
            }
        }

        private void upSelectedItemBtn_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void downSelectedItemBtn_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openProjectFileDialog.FileName;
                ReadProjectFile(selectedFilePath);
            }
        }

        private void UpdateRecentlyOpenedFilesMenu()
        {
            var recentlyOpenedFiles = Properties.Settings.Default.recentlyOpenedFiles;
            recentlyOpenedToolStripMenuItem.DropDownItems.Clear();

            if (recentlyOpenedFiles != null)
            {
                foreach (var file in recentlyOpenedFiles)
                {
                    if (File.Exists(file))
                    {
                        ToolStripMenuItem fileItem = new ToolStripMenuItem(file);
                        fileItem.Click += (sender, e) => ReadProjectFile(file);
                        recentlyOpenedToolStripMenuItem.DropDownItems.Add(fileItem);
                    }
                }
            }
            else
            {
                recentlyOpenedFiles = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.recentlyOpenedFiles = recentlyOpenedFiles;
                Properties.Settings.Default.Save();
            }
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/yevhenii-sir?tab=repositories";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}