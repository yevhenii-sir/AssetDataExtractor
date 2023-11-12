namespace AssetDataExtractorPro
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            roomslb = new ListBox();
            layerslb = new ListBox();
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            recentlyOpenedToolStripMenuItem = new ToolStripMenuItem();
            projectTSM = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            sourceToolStripMenuItem = new ToolStripMenuItem();
            versionToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            resultFormattingTB = new TextBox();
            label3 = new Label();
            dataFormatGV = new DataGridView();
            addElementFormatting = new Button();
            deleteFormattingDataBtn = new Button();
            upSelectedItemBtn = new Button();
            downSelectedItemBtn = new Button();
            openProjectFileDialog = new OpenFileDialog();
            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataFormatGV).BeginInit();
            SuspendLayout();
            // 
            // roomslb
            // 
            roomslb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            roomslb.FormattingEnabled = true;
            roomslb.ItemHeight = 15;
            roomslb.Location = new Point(12, 45);
            roomslb.Name = "roomslb";
            roomslb.Size = new Size(225, 469);
            roomslb.TabIndex = 0;
            roomslb.SelectedIndexChanged += roomslb_SelectedIndexChanged;
            // 
            // layerslb
            // 
            layerslb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            layerslb.FormattingEnabled = true;
            layerslb.ItemHeight = 15;
            layerslb.Location = new Point(243, 45);
            layerslb.Name = "layerslb";
            layerslb.Size = new Size(225, 469);
            layerslb.TabIndex = 1;
            layerslb.SelectedIndexChanged += layerslb_SelectedIndexChanged;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, projectTSM, refreshToolStripMenuItem, infoToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(977, 24);
            mainMenuStrip.TabIndex = 3;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFileToolStripMenuItem, recentlyOpenedToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new Size(171, 22);
            openFileToolStripMenuItem.Text = "Open...";
            openFileToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            // 
            // recentlyOpenedToolStripMenuItem
            // 
            recentlyOpenedToolStripMenuItem.Name = "recentlyOpenedToolStripMenuItem";
            recentlyOpenedToolStripMenuItem.Size = new Size(171, 22);
            recentlyOpenedToolStripMenuItem.Text = "Recently opened...";
            // 
            // projectTSM
            // 
            projectTSM.Name = "projectTSM";
            projectTSM.Size = new Size(61, 20);
            projectTSM.Text = "Projects";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(58, 20);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            infoToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            infoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sourceToolStripMenuItem, versionToolStripMenuItem });
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(40, 20);
            infoToolStripMenuItem.Text = "Info";
            // 
            // sourceToolStripMenuItem
            // 
            sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            sourceToolStripMenuItem.Size = new Size(118, 22);
            sourceToolStripMenuItem.Text = "Source";
            sourceToolStripMenuItem.Click += sourceToolStripMenuItem_Click;
            // 
            // versionToolStripMenuItem
            // 
            versionToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            versionToolStripMenuItem.Size = new Size(118, 22);
            versionToolStripMenuItem.Text = "Version: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(105, 27);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 4;
            label1.Text = "ROOMS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(334, 27);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 5;
            label2.Text = "LAYERS";
            // 
            // resultFormattingTB
            // 
            resultFormattingTB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultFormattingTB.Location = new Point(474, 45);
            resultFormattingTB.Multiline = true;
            resultFormattingTB.Name = "resultFormattingTB";
            resultFormattingTB.ScrollBars = ScrollBars.Vertical;
            resultFormattingTB.Size = new Size(491, 218);
            resultFormattingTB.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(698, 27);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 7;
            label3.Text = "RESULT";
            // 
            // dataFormatGV
            // 
            dataFormatGV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataFormatGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataFormatGV.Location = new Point(474, 269);
            dataFormatGV.Name = "dataFormatGV";
            dataFormatGV.RowTemplate.Height = 25;
            dataFormatGV.Size = new Size(491, 218);
            dataFormatGV.TabIndex = 8;
            // 
            // addElementFormatting
            // 
            addElementFormatting.Anchor = AnchorStyles.Bottom;
            addElementFormatting.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addElementFormatting.Location = new Point(474, 493);
            addElementFormatting.Name = "addElementFormatting";
            addElementFormatting.Size = new Size(140, 23);
            addElementFormatting.TabIndex = 9;
            addElementFormatting.Text = "ADD ELEMENT";
            addElementFormatting.UseVisualStyleBackColor = true;
            addElementFormatting.Click += addElementFormatting_Click;
            // 
            // deleteFormattingDataBtn
            // 
            deleteFormattingDataBtn.Anchor = AnchorStyles.Bottom;
            deleteFormattingDataBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            deleteFormattingDataBtn.Location = new Point(620, 493);
            deleteFormattingDataBtn.Name = "deleteFormattingDataBtn";
            deleteFormattingDataBtn.Size = new Size(168, 23);
            deleteFormattingDataBtn.TabIndex = 10;
            deleteFormattingDataBtn.Text = "DELETE SELECTED ELEMENT";
            deleteFormattingDataBtn.UseVisualStyleBackColor = true;
            deleteFormattingDataBtn.Click += deleteFormattingDataBtn_Click;
            // 
            // upSelectedItemBtn
            // 
            upSelectedItemBtn.Anchor = AnchorStyles.Bottom;
            upSelectedItemBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            upSelectedItemBtn.Location = new Point(794, 493);
            upSelectedItemBtn.Name = "upSelectedItemBtn";
            upSelectedItemBtn.Size = new Size(83, 23);
            upSelectedItemBtn.TabIndex = 11;
            upSelectedItemBtn.Text = "UP";
            upSelectedItemBtn.UseVisualStyleBackColor = true;
            upSelectedItemBtn.Click += upSelectedItemBtn_Click;
            // 
            // downSelectedItemBtn
            // 
            downSelectedItemBtn.Anchor = AnchorStyles.Bottom;
            downSelectedItemBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            downSelectedItemBtn.Location = new Point(882, 493);
            downSelectedItemBtn.Name = "downSelectedItemBtn";
            downSelectedItemBtn.Size = new Size(83, 23);
            downSelectedItemBtn.TabIndex = 12;
            downSelectedItemBtn.Text = "DOWN";
            downSelectedItemBtn.UseVisualStyleBackColor = true;
            downSelectedItemBtn.Click += downSelectedItemBtn_Click;
            // 
            // openProjectFileDialog
            // 
            openProjectFileDialog.DefaultExt = "yyp";
            openProjectFileDialog.Filter = "GameMaker Files (*.yyp, *.yy)|*.yyp;*.yy|All files (*.*)|*.*";
            openProjectFileDialog.RestoreDirectory = true;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 521);
            Controls.Add(downSelectedItemBtn);
            Controls.Add(upSelectedItemBtn);
            Controls.Add(deleteFormattingDataBtn);
            Controls.Add(addElementFormatting);
            Controls.Add(dataFormatGV);
            Controls.Add(label3);
            Controls.Add(resultFormattingTB);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(layerslb);
            Controls.Add(roomslb);
            Controls.Add(mainMenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenuStrip;
            MinimumSize = new Size(993, 560);
            Name = "MainForm";
            Text = "Data Extractor";
            DragDrop += MainForm_DragDrop;
            DragEnter += Form1_DragEnter;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataFormatGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox roomslb;
        private ListBox layerslb;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem projectTSM;
        private Label label1;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private Label label2;
        private TextBox resultFormattingTB;
        private Label label3;
        private DataGridView dataFormatGV;
        private Button addElementFormatting;
        private Button deleteFormattingDataBtn;
        private Button upSelectedItemBtn;
        private Button downSelectedItemBtn;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem recentlyOpenedToolStripMenuItem;
        private OpenFileDialog openProjectFileDialog;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem versionToolStripMenuItem;
        private ToolStripMenuItem sourceToolStripMenuItem;
    }
}