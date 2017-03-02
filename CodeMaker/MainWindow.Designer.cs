namespace DMedia.CodeMaker
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_Column = new System.Windows.Forms.Button();
            this.Chk_CheckAll = new System.Windows.Forms.CheckBox();
            this.Btn_Code = new System.Windows.Forms.Button();
            this.DataGrid_Columns = new System.Windows.Forms.DataGridView();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNullAble = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tree_Images = new System.Windows.Forms.ImageList(this.components);
            this.GboxProperties = new System.Windows.Forms.GroupBox();
            this.DataGrid_Properties = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RtbCode = new System.Windows.Forms.RichTextBox();
            this.Tree_Template = new System.Windows.Forms.TreeView();
            this.Cmb_Tables = new System.Windows.Forms.ComboBox();
            this.GboxTemplates = new System.Windows.Forms.GroupBox();
            this.GboxColumns = new System.Windows.Forms.GroupBox();
            this.BtnOpenDir = new System.Windows.Forms.Button();
            this.Btn_File = new System.Windows.Forms.Button();
            this.GboxDbTables = new System.Windows.Forms.GroupBox();
            this.MenuStripBox = new System.Windows.Forms.MenuStrip();
            this.MenuItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItembuild = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBuildAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Columns)).BeginInit();
            this.GboxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Properties)).BeginInit();
            this.GboxTemplates.SuspendLayout();
            this.GboxColumns.SuspendLayout();
            this.GboxDbTables.SuspendLayout();
            this.MenuStripBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Column
            // 
            this.Btn_Column.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Column.Location = new System.Drawing.Point(448, 16);
            this.Btn_Column.Name = "Btn_Column";
            this.Btn_Column.Size = new System.Drawing.Size(55, 23);
            this.Btn_Column.TabIndex = 20;
            this.Btn_Column.Text = "字 段";
            this.Btn_Column.UseVisualStyleBackColor = true;
            this.Btn_Column.Click += new System.EventHandler(this.btn_Column_Click);
            // 
            // Chk_CheckAll
            // 
            this.Chk_CheckAll.AutoSize = true;
            this.Chk_CheckAll.Location = new System.Drawing.Point(6, 22);
            this.Chk_CheckAll.Name = "Chk_CheckAll";
            this.Chk_CheckAll.Size = new System.Drawing.Size(48, 16);
            this.Chk_CheckAll.TabIndex = 18;
            this.Chk_CheckAll.Text = "全选";
            this.Chk_CheckAll.UseVisualStyleBackColor = true;
            this.Chk_CheckAll.CheckedChanged += new System.EventHandler(this.chk_CheckAll_CheckedChanged);
            // 
            // Btn_Code
            // 
            this.Btn_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Code.Location = new System.Drawing.Point(513, 16);
            this.Btn_Code.Name = "Btn_Code";
            this.Btn_Code.Size = new System.Drawing.Size(66, 23);
            this.Btn_Code.TabIndex = 16;
            this.Btn_Code.Text = "查看代码";
            this.Btn_Code.UseVisualStyleBackColor = true;
            this.Btn_Code.Click += new System.EventHandler(this.btn_Code_Click);
            // 
            // DataGrid_Columns
            // 
            this.DataGrid_Columns.AllowUserToAddRows = false;
            this.DataGrid_Columns.AllowUserToDeleteRows = false;
            this.DataGrid_Columns.AllowUserToResizeColumns = false;
            this.DataGrid_Columns.AllowUserToResizeRows = false;
            this.DataGrid_Columns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid_Columns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGrid_Columns.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DataGrid_Columns.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGrid_Columns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid_Columns.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid_Columns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGrid_Columns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGrid_Columns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.FieldName,
            this.Description,
            this.DataType,
            this.Length,
            this.IsNullAble,
            this.DefaultValue});
            this.DataGrid_Columns.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGrid_Columns.Location = new System.Drawing.Point(7, 45);
            this.DataGrid_Columns.Name = "DataGrid_Columns";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid_Columns.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGrid_Columns.RowHeadersVisible = false;
            this.DataGrid_Columns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGrid_Columns.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Bisque;
            this.DataGrid_Columns.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGrid_Columns.RowTemplate.Height = 23;
            this.DataGrid_Columns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid_Columns.Size = new System.Drawing.Size(571, 392);
            this.DataGrid_Columns.TabIndex = 15;
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.FalseValue = "0";
            this.ColumnIndex.FillWeight = 53.29949F;
            this.ColumnIndex.HeaderText = "选";
            this.ColumnIndex.IndeterminateValue = "";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIndex.TrueValue = "1";
            // 
            // FieldName
            // 
            this.FieldName.DataPropertyName = "Name";
            this.FieldName.FillWeight = 107.7834F;
            this.FieldName.HeaderText = "名称";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            this.FieldName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Comments";
            this.Description.FillWeight = 107.7834F;
            this.Description.HeaderText = "注释";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DataType
            // 
            this.DataType.DataPropertyName = "DataType";
            this.DataType.FillWeight = 107.7834F;
            this.DataType.HeaderText = "类型";
            this.DataType.Name = "DataType";
            this.DataType.ReadOnly = true;
            this.DataType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            this.Length.FillWeight = 107.7834F;
            this.Length.HeaderText = "长度";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // IsNullAble
            // 
            this.IsNullAble.DataPropertyName = "IsNullAble";
            this.IsNullAble.FillWeight = 107.7834F;
            this.IsNullAble.HeaderText = "允许空";
            this.IsNullAble.Name = "IsNullAble";
            this.IsNullAble.ReadOnly = true;
            this.IsNullAble.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsNullAble.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DefaultValue
            // 
            this.DefaultValue.DataPropertyName = "DefaultValue";
            this.DefaultValue.FillWeight = 107.7834F;
            this.DefaultValue.HeaderText = "默认值";
            this.DefaultValue.Name = "DefaultValue";
            this.DefaultValue.ReadOnly = true;
            this.DefaultValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Tree_Images
            // 
            this.Tree_Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Tree_Images.ImageStream")));
            this.Tree_Images.TransparentColor = System.Drawing.Color.Transparent;
            this.Tree_Images.Images.SetKeyName(0, "folder_closed_16_h.gif");
            this.Tree_Images.Images.SetKeyName(1, "Table.gif");
            this.Tree_Images.Images.SetKeyName(2, "Columns.gif");
            this.Tree_Images.Images.SetKeyName(3, "WorkSpace.gif");
            this.Tree_Images.Images.SetKeyName(4, "RelationshipsHS.png");
            this.Tree_Images.Images.SetKeyName(5, "Join.png");
            this.Tree_Images.Images.SetKeyName(6, "DatasetView_Column.png");
            this.Tree_Images.Images.SetKeyName(7, "");
            // 
            // GboxProperties
            // 
            this.GboxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GboxProperties.Controls.Add(this.DataGrid_Properties);
            this.GboxProperties.Location = new System.Drawing.Point(6, 291);
            this.GboxProperties.Name = "GboxProperties";
            this.GboxProperties.Size = new System.Drawing.Size(222, 182);
            this.GboxProperties.TabIndex = 16;
            this.GboxProperties.TabStop = false;
            this.GboxProperties.Text = "属性定义：";
            // 
            // DataGrid_Properties
            // 
            this.DataGrid_Properties.AllowUserToAddRows = false;
            this.DataGrid_Properties.AllowUserToDeleteRows = false;
            this.DataGrid_Properties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGrid_Properties.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGrid_Properties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid_Properties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Properties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.DataGrid_Properties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataGrid_Properties.Location = new System.Drawing.Point(6, 20);
            this.DataGrid_Properties.Name = "DataGrid_Properties";
            this.DataGrid_Properties.RowHeadersVisible = false;
            this.DataGrid_Properties.RowTemplate.Height = 23;
            this.DataGrid_Properties.Size = new System.Drawing.Size(210, 150);
            this.DataGrid_Properties.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "Description";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "属性";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 60;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Name";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "名称";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "Value";
            this.Column2.HeaderText = "值";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 80;
            // 
            // RtbCode
            // 
            this.RtbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtbCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RtbCode.Location = new System.Drawing.Point(7, 44);
            this.RtbCode.Name = "RtbCode";
            this.RtbCode.Size = new System.Drawing.Size(571, 393);
            this.RtbCode.TabIndex = 17;
            this.RtbCode.Text = "";
            // 
            // Tree_Template
            // 
            this.Tree_Template.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tree_Template.BackColor = System.Drawing.SystemColors.Control;
            this.Tree_Template.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tree_Template.ImageIndex = 0;
            this.Tree_Template.ImageList = this.Tree_Images;
            this.Tree_Template.Location = new System.Drawing.Point(6, 20);
            this.Tree_Template.Name = "Tree_Template";
            this.Tree_Template.SelectedImageIndex = 0;
            this.Tree_Template.Size = new System.Drawing.Size(206, 163);
            this.Tree_Template.TabIndex = 2;
            // 
            // Cmb_Tables
            // 
            this.Cmb_Tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Tables.FormattingEnabled = true;
            this.Cmb_Tables.Location = new System.Drawing.Point(6, 22);
            this.Cmb_Tables.Name = "Cmb_Tables";
            this.Cmb_Tables.Size = new System.Drawing.Size(206, 20);
            this.Cmb_Tables.TabIndex = 5;
            this.Cmb_Tables.SelectedValueChanged += new System.EventHandler(this.cbb_Tables_SelectedValueChanged);
            // 
            // GboxTemplates
            // 
            this.GboxTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GboxTemplates.Controls.Add(this.Tree_Template);
            this.GboxTemplates.Location = new System.Drawing.Point(6, 95);
            this.GboxTemplates.Name = "GboxTemplates";
            this.GboxTemplates.Size = new System.Drawing.Size(222, 189);
            this.GboxTemplates.TabIndex = 15;
            this.GboxTemplates.TabStop = false;
            this.GboxTemplates.Text = "代码模板：";
            // 
            // GboxColumns
            // 
            this.GboxColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GboxColumns.Controls.Add(this.BtnOpenDir);
            this.GboxColumns.Controls.Add(this.Btn_File);
            this.GboxColumns.Controls.Add(this.Btn_Column);
            this.GboxColumns.Controls.Add(this.Chk_CheckAll);
            this.GboxColumns.Controls.Add(this.Btn_Code);
            this.GboxColumns.Controls.Add(this.DataGrid_Columns);
            this.GboxColumns.Controls.Add(this.RtbCode);
            this.GboxColumns.Location = new System.Drawing.Point(237, 31);
            this.GboxColumns.Name = "GboxColumns";
            this.GboxColumns.Size = new System.Drawing.Size(585, 442);
            this.GboxColumns.TabIndex = 17;
            this.GboxColumns.TabStop = false;
            this.GboxColumns.Text = "字段属性：";
            // 
            // BtnOpenDir
            // 
            this.BtnOpenDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpenDir.Location = new System.Drawing.Point(225, 16);
            this.BtnOpenDir.Name = "BtnOpenDir";
            this.BtnOpenDir.Size = new System.Drawing.Size(88, 23);
            this.BtnOpenDir.TabIndex = 22;
            this.BtnOpenDir.Text = "打开生成目录";
            this.BtnOpenDir.UseVisualStyleBackColor = true;
            this.BtnOpenDir.Click += new System.EventHandler(this.BtnOpenDir_Click);
            // 
            // Btn_File
            // 
            this.Btn_File.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_File.Location = new System.Drawing.Point(328, 16);
            this.Btn_File.Name = "Btn_File";
            this.Btn_File.Size = new System.Drawing.Size(111, 23);
            this.Btn_File.TabIndex = 21;
            this.Btn_File.Text = "生成全部代码文件";
            this.Btn_File.UseVisualStyleBackColor = true;
            this.Btn_File.Click += new System.EventHandler(this.Btn_File_Click);
            // 
            // GboxDbTables
            // 
            this.GboxDbTables.Controls.Add(this.Cmb_Tables);
            this.GboxDbTables.Location = new System.Drawing.Point(6, 31);
            this.GboxDbTables.Name = "GboxDbTables";
            this.GboxDbTables.Size = new System.Drawing.Size(222, 58);
            this.GboxDbTables.TabIndex = 14;
            this.GboxDbTables.TabStop = false;
            this.GboxDbTables.Text = "数 据 表：";
            // 
            // MenuStripBox
            // 
            this.MenuStripBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemMain,
            this.MenuItembuild,
            this.MenuItemHelp});
            this.MenuStripBox.Location = new System.Drawing.Point(0, 0);
            this.MenuStripBox.Name = "MenuStripBox";
            this.MenuStripBox.Size = new System.Drawing.Size(831, 25);
            this.MenuStripBox.TabIndex = 18;
            this.MenuStripBox.Text = "menuStrip1";
            // 
            // MenuItemMain
            // 
            this.MenuItemMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExit});
            this.MenuItemMain.Name = "MenuItemMain";
            this.MenuItemMain.Size = new System.Drawing.Size(58, 21);
            this.MenuItemMain.Text = "菜单(&F)";
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(116, 22);
            this.MenuItemExit.Text = "退出(&X)";
            // 
            // MenuItembuild
            // 
            this.MenuItembuild.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemBuildAll});
            this.MenuItembuild.Name = "MenuItembuild";
            this.MenuItembuild.Size = new System.Drawing.Size(60, 21);
            this.MenuItembuild.Text = "生成(&C)";
            // 
            // MenuItemBuildAll
            // 
            this.MenuItemBuildAll.Name = "MenuItemBuildAll";
            this.MenuItemBuildAll.Size = new System.Drawing.Size(164, 22);
            this.MenuItemBuildAll.Text = "生成全部文件(&B)";
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAbout});
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(61, 21);
            this.MenuItemHelp.Text = "帮助(&H)";
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.Size = new System.Drawing.Size(116, 22);
            this.MenuItemAbout.Text = "关于(&A)";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 500);
            this.Controls.Add(this.GboxProperties);
            this.Controls.Add(this.GboxTemplates);
            this.Controls.Add(this.GboxColumns);
            this.Controls.Add(this.GboxDbTables);
            this.Controls.Add(this.MenuStripBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStripBox;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeMaker v2.0";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Columns)).EndInit();
            this.GboxProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Properties)).EndInit();
            this.GboxTemplates.ResumeLayout(false);
            this.GboxColumns.ResumeLayout(false);
            this.GboxColumns.PerformLayout();
            this.GboxDbTables.ResumeLayout(false);
            this.MenuStripBox.ResumeLayout(false);
            this.MenuStripBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Column;
        private System.Windows.Forms.CheckBox Chk_CheckAll;
        private System.Windows.Forms.Button Btn_Code;
        private System.Windows.Forms.DataGridView DataGrid_Columns;
        private System.Windows.Forms.ImageList Tree_Images;
        private System.Windows.Forms.GroupBox GboxProperties;
        private System.Windows.Forms.DataGridView DataGrid_Properties;
        private System.Windows.Forms.RichTextBox RtbCode;
        private System.Windows.Forms.TreeView Tree_Template;
        private System.Windows.Forms.ComboBox Cmb_Tables;
        private System.Windows.Forms.GroupBox GboxTemplates;
        private System.Windows.Forms.GroupBox GboxColumns;
        private System.Windows.Forms.GroupBox GboxDbTables;
        private System.Windows.Forms.Button Btn_File;
        private System.Windows.Forms.MenuStrip MenuStripBox;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMain;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItembuild;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBuildAll;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNullAble;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultValue;
        private System.Windows.Forms.Button BtnOpenDir;
    }
}