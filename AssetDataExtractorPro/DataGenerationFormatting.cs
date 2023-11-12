using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetDataExtractorPro
{
    public class DataGenerationFormatting
    {
        private DataGridView _gridView;
        public BindingList<FormattingTextEntry> Data { get; set; } = new BindingList<FormattingTextEntry>();
        private string[] _propertiesName = new string[] { 
            "spriteId.name",
            "spriteId.path",
            "headPosition",
            "rotation",
            "scaleX",
            "scaleY",
            "animationSpeed",
            "colour",
            "ignore",
            "x",
            "y",
            "name",
        };

        public DataGenerationFormatting(DataGridView gridView)
        {
            this._gridView = gridView;
            InitializeDataGridView();
            
            var savedData = Properties.Settings.Default.formattingDataList;
            if (string.IsNullOrEmpty(savedData))
            {
                Data.Add(new FormattingTextEntry("[", false));
                Data.Add(new FormattingTextEntry("spriteId.name", true));
                Data.Add(new FormattingTextEntry(", ", false));
                Data.Add(new FormattingTextEntry("x", true));
                Data.Add(new FormattingTextEntry(", ", false));
                Data.Add(new FormattingTextEntry("y", true));
                Data.Add(new FormattingTextEntry("],", false));

                Properties.Settings.Default.formattingDataList = JsonConvert.SerializeObject(Data);
                Properties.Settings.Default.Save();
            } else
            {
                Data = JsonConvert.DeserializeObject<BindingList<FormattingTextEntry>>(savedData);
            }

            gridView.DataSource = Data;
            Task task = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                foreach (DataGridViewRow row in _gridView.Rows)
                {
                    
                    ToggleCellType(row.Index);
                }
            }); 
        }

        public void SaveDataFormatting()
        {
            Properties.Settings.Default.formattingDataList = JsonConvert.SerializeObject(Data);
            Properties.Settings.Default.Save();
        }

        private void InitializeDataGridView()
        {
            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Text";
            textColumn.Name = "TextColumn";
            textColumn.DataPropertyName = "Text";
            textColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _gridView.Columns.Add(textColumn);

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "ButtonColumn";
            buttonColumn.Text = "Change";
            buttonColumn.HeaderText = "Change Type";
            buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttonColumn.UseColumnTextForButtonValue = true;
            _gridView.Columns.Add(buttonColumn);

            _gridView.CellClick += DataGridView_CellClick;
            _gridView.CellEndEdit += DataGridView_EndEdit;
            //_gridView.CellFormatting += DataGridView_CellFormatting;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _gridView.Columns["ButtonColumn"].Index && e.RowIndex >= 0)
            {
                _gridView.BeginInvoke(new MethodInvoker(() => {
                    ToggleCellType(e.RowIndex, true);
                    _gridView.Refresh();
                }));
                //_gridView.InvalidateRow(e.RowIndex); // Refresh the row
            }
        }
        private void DataGridView_EndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in _gridView.Rows)
            {
                _gridView.BeginInvoke(new MethodInvoker(() => {
                    ToggleCellType(row.Index);
                    _gridView.Refresh();
                }));
            }
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            _gridView.BeginInvoke(new MethodInvoker(() => {
                if (e.ColumnIndex == _gridView.Columns["TextColumn"].Index && e.RowIndex >= 0)
                {
                    var cellData = Data[e.RowIndex];
                    if (cellData.IsComboBoxEnabled)
                    {
                        e.CellStyle.DataSourceNullValue = _gridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    }
                    else
                    {
                        e.CellStyle.DataSourceNullValue = _gridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewTextBoxCell;
                    }
                }
            }));
        }

        private void ToggleCellType(int rowIndex, bool changeType = false)
        {
            _gridView.BeginInvoke(new MethodInvoker(() =>
            {
                var cellData = Data[rowIndex];
                if (changeType) cellData.IsComboBoxEnabled = !cellData.IsComboBoxEnabled;

                Debug.WriteLine(cellData.Text + " " + cellData.IsComboBoxEnabled);

                if (cellData.IsComboBoxEnabled)
                {
                    DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                    // Assuming _propertiesName is a string array of valid items for the combo box.
                    comboBoxCell.Items.AddRange(_propertiesName);

                    // Set default value or leave it null if Text is not in _propertiesName.
                    if (_propertiesName.Contains(cellData.Text))
                    {
                        comboBoxCell.Value = cellData.Text;
                    }

                    _gridView.Rows[rowIndex].Cells["TextColumn"] = comboBoxCell;

                    // This is important: Set the Value of the ComboBoxCell after it has been added to the row.
                    if (comboBoxCell.Items.Contains(cellData.Text))
                    {
                        comboBoxCell.Value = cellData.Text;
                    }
                    else if (comboBoxCell.Items.Count > 0)
                    {
                        comboBoxCell.Value = comboBoxCell.Items[0]; // Default to first item if necessary
                    }
                }
                else
                {
                    DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
                    textBoxCell.Value = cellData.Text;
                    _gridView.Rows[rowIndex].Cells["TextColumn"] = textBoxCell;
                }
            }));
        }
    }
}
