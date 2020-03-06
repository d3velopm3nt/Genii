namespace DALX_UI.UserControls
{
    partial class ucProjectManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProjectManager));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSolution = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelDatabase = new System.Windows.Forms.Panel();
            this.btnManage = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.lblTemplatePath = new System.Windows.Forms.Label();
            this.dgvTemplates = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbuttonRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolbuttonRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgvGenerateFiles = new System.Windows.Forms.DataGridView();
            this.Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvExtensions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.lblSaveChanges = new System.Windows.Forms.Label();
            this.btnGenEx = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenerateFiles)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtensions)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSolution);
            this.panel1.Controls.Add(this.lblProject);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 46);
            this.panel1.TabIndex = 2;
            // 
            // lblSolution
            // 
            this.lblSolution.AutoSize = true;
            this.lblSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolution.Location = new System.Drawing.Point(11, 5);
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(66, 16);
            this.lblSolution.TabIndex = 2;
            this.lblSolution.Text = "Solution - ";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(22, 26);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(55, 15);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project - ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Project Path:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 112);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(684, 329);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelDatabase);
            this.tabPage1.Controls.Add(this.btnManage);
            this.tabPage1.Controls.Add(this.btnSetup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(676, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelDatabase
            // 
            this.panelDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDatabase.Location = new System.Drawing.Point(10, 44);
            this.panelDatabase.Name = "panelDatabase";
            this.panelDatabase.Size = new System.Drawing.Size(660, 253);
            this.panelDatabase.TabIndex = 11;
            // 
            // btnManage
            // 
            this.btnManage.Location = new System.Drawing.Point(124, 15);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(103, 23);
            this.btnManage.TabIndex = 10;
            this.btnManage.Text = "View Tables";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(10, 15);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(108, 23);
            this.btnSetup.TabIndex = 9;
            this.btnSetup.Text = "Connection";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.btnSelectPath);
            this.tabPage2.Controls.Add(this.lblTemplatePath);
            this.tabPage2.Controls.Add(this.dgvTemplates);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(676, 303);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Templates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(9, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Path";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(101, 6);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(82, 23);
            this.btnSelectPath.TabIndex = 3;
            this.btnSelectPath.Text = "Set Path";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // lblTemplatePath
            // 
            this.lblTemplatePath.AutoSize = true;
            this.lblTemplatePath.Location = new System.Drawing.Point(189, 11);
            this.lblTemplatePath.Name = "lblTemplatePath";
            this.lblTemplatePath.Size = new System.Drawing.Size(29, 13);
            this.lblTemplatePath.TabIndex = 2;
            this.lblTemplatePath.Text = "Path";
            // 
            // dgvTemplates
            // 
            this.dgvTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTemplates.BackgroundColor = System.Drawing.Color.White;
            this.dgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Enable});
            this.dgvTemplates.Location = new System.Drawing.Point(9, 35);
            this.dgvTemplates.Name = "dgvTemplates";
            this.dgvTemplates.RowHeadersVisible = false;
            this.dgvTemplates.Size = new System.Drawing.Size(661, 262);
            this.dgvTemplates.TabIndex = 0;
            this.dgvTemplates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTemplates_CellClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Template";
            this.Column6.Name = "Column6";
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Generate Path";
            this.Column7.Name = "Column7";
            // 
            // Enable
            // 
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Enable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.toolStrip1);
            this.tabPage3.Controls.Add(this.dgvGenerateFiles);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(676, 303);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generate";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbuttonRun,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolbuttonRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(670, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbuttonRun
            // 
            this.toolbuttonRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbuttonRun.Image = ((System.Drawing.Image)(resources.GetObject("toolbuttonRun.Image")));
            this.toolbuttonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbuttonRun.Name = "toolbuttonRun";
            this.toolbuttonRun.Size = new System.Drawing.Size(23, 22);
            this.toolbuttonRun.Text = "toolStripButton1";
            this.toolbuttonRun.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolbuttonRefresh
            // 
            this.toolbuttonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbuttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolbuttonRefresh.Image")));
            this.toolbuttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbuttonRefresh.Name = "toolbuttonRefresh";
            this.toolbuttonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolbuttonRefresh.Text = "toolStripButton4";
            this.toolbuttonRefresh.Click += new System.EventHandler(this.toolbuttonRefresh_Click);
            // 
            // dgvGenerateFiles
            // 
            this.dgvGenerateFiles.AllowUserToAddRows = false;
            this.dgvGenerateFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGenerateFiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvGenerateFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenerateFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Temp,
            this.Table,
            this.DT,
            this.Comment});
            this.dgvGenerateFiles.Location = new System.Drawing.Point(6, 29);
            this.dgvGenerateFiles.Name = "dgvGenerateFiles";
            this.dgvGenerateFiles.RowHeadersVisible = false;
            this.dgvGenerateFiles.Size = new System.Drawing.Size(664, 265);
            this.dgvGenerateFiles.TabIndex = 0;
            // 
            // Temp
            // 
            this.Temp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Temp.HeaderText = "Template";
            this.Temp.Name = "Temp";
            // 
            // Table
            // 
            this.Table.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Table.HeaderText = "Table";
            this.Table.Name = "Table";
            // 
            // DT
            // 
            this.DT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DT.HeaderText = "DateTime";
            this.DT.Name = "DT";
            this.DT.Width = 200;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnGenEx);
            this.tabPage4.Controls.Add(this.dgvExtensions);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(676, 303);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Extensions";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvExtensions
            // 
            this.dgvExtensions.AllowUserToAddRows = false;
            this.dgvExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExtensions.BackgroundColor = System.Drawing.Color.White;
            this.dgvExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtensions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.dgvExtensions.Location = new System.Drawing.Point(6, 35);
            this.dgvExtensions.Name = "dgvExtensions";
            this.dgvExtensions.RowHeadersVisible = false;
            this.dgvExtensions.Size = new System.Drawing.Size(664, 249);
            this.dgvExtensions.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Existing File";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Total Extensions";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // txtpath
            // 
            this.txtpath.Enabled = false;
            this.txtpath.Location = new System.Drawing.Point(162, 55);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(409, 20);
            this.txtpath.TabIndex = 7;
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(577, 53);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(75, 23);
            this.btnSavePath.TabIndex = 8;
            this.btnSavePath.Text = "Save";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Visible = false;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Location = new System.Drawing.Point(7, 53);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(75, 23);
            this.btnConfigure.TabIndex = 3;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(7, 82);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(146, 23);
            this.btnSaveChanges.TabIndex = 9;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Visible = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // lblSaveChanges
            // 
            this.lblSaveChanges.AutoSize = true;
            this.lblSaveChanges.Location = new System.Drawing.Point(159, 87);
            this.lblSaveChanges.Name = "lblSaveChanges";
            this.lblSaveChanges.Size = new System.Drawing.Size(70, 13);
            this.lblSaveChanges.TabIndex = 10;
            this.lblSaveChanges.Text = "Save Results";
            this.lblSaveChanges.Visible = false;
            // 
            // btnGenEx
            // 
            this.btnGenEx.Location = new System.Drawing.Point(9, 6);
            this.btnGenEx.Name = "btnGenEx";
            this.btnGenEx.Size = new System.Drawing.Size(148, 23);
            this.btnGenEx.TabIndex = 11;
            this.btnGenEx.Text = "Generate Extensions";
            this.btnGenEx.UseVisualStyleBackColor = true;
            this.btnGenEx.Click += new System.EventHandler(this.btnGenEx_Click);
            // 
            // ucProjectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblSaveChanges);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.panel1);
            this.Name = "ucProjectManager";
            this.Size = new System.Drawing.Size(690, 441);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenerateFiles)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtensions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSolution;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbuttonRun;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView dgvGenerateFiles;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Panel panelDatabase;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvTemplates;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Label lblTemplatePath;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label lblSaveChanges;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripButton toolbuttonRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvExtensions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.Button btnGenEx;
    }
}
