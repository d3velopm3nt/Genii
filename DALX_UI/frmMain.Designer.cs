namespace DALX_UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelManager = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemSolution = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.treeLibrary = new System.Windows.Forms.TreeView();
            this.contextMenuTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInWindowsExporerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatuslblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.openTargetProjectFodlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuTreeView.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panelManager);
            this.panelMain.Controls.Add(this.toolStrip1);
            this.panelMain.Controls.Add(this.treeLibrary);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 35);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1398, 799);
            this.panelMain.TabIndex = 1;
            // 
            // panelManager
            // 
            this.panelManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelManager.BackColor = System.Drawing.Color.White;
            this.panelManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelManager.Location = new System.Drawing.Point(356, 66);
            this.panelManager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelManager.Name = "panelManager";
            this.panelManager.Size = new System.Drawing.Size(1035, 693);
            this.panelManager.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolItemSolution,
            this.toolStripSeparator2,
            this.toolItemProject,
            this.toolStripSeparator3,
            this.toolItemFolder,
            this.toolStripSeparator4,
            this.toolItemFile,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1396, 62);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 62);
            // 
            // toolItemSolution
            // 
            this.toolItemSolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolItemSolution.ForeColor = System.Drawing.Color.White;
            this.toolItemSolution.Image = ((System.Drawing.Image)(resources.GetObject("toolItemSolution.Image")));
            this.toolItemSolution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemSolution.Name = "toolItemSolution";
            this.toolItemSolution.Size = new System.Drawing.Size(133, 57);
            this.toolItemSolution.Text = "Select Solution";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 62);
            // 
            // toolItemProject
            // 
            this.toolItemProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolItemProject.ForeColor = System.Drawing.Color.White;
            this.toolItemProject.Image = ((System.Drawing.Image)(resources.GetObject("toolItemProject.Image")));
            this.toolItemProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemProject.Name = "toolItemProject";
            this.toolItemProject.Size = new System.Drawing.Size(70, 57);
            this.toolItemProject.Text = "Project";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 62);
            // 
            // toolItemFolder
            // 
            this.toolItemFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolItemFolder.ForeColor = System.Drawing.Color.White;
            this.toolItemFolder.Image = ((System.Drawing.Image)(resources.GetObject("toolItemFolder.Image")));
            this.toolItemFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemFolder.Name = "toolItemFolder";
            this.toolItemFolder.Size = new System.Drawing.Size(148, 57);
            this.toolItemFolder.Text = "Selected XFolder";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 62);
            // 
            // toolItemFile
            // 
            this.toolItemFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolItemFile.ForeColor = System.Drawing.Color.White;
            this.toolItemFile.Image = ((System.Drawing.Image)(resources.GetObject("toolItemFile.Image")));
            this.toolItemFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemFile.Name = "toolItemFile";
            this.toolItemFile.Size = new System.Drawing.Size(104, 57);
            this.toolItemFile.Text = "Select XFile";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 62);
            // 
            // treeLibrary
            // 
            this.treeLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeLibrary.ContextMenuStrip = this.contextMenuTreeView;
            this.treeLibrary.ImageIndex = 0;
            this.treeLibrary.ImageList = this.imageList1;
            this.treeLibrary.Location = new System.Drawing.Point(4, 66);
            this.treeLibrary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeLibrary.Name = "treeLibrary";
            this.treeLibrary.SelectedImageIndex = 0;
            this.treeLibrary.Size = new System.Drawing.Size(340, 692);
            this.treeLibrary.TabIndex = 0;
            this.treeLibrary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeLibrary_AfterSelect);
            this.treeLibrary.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeLibrary_NodeMouseClick);
            // 
            // contextMenuTreeView
            // 
            this.contextMenuTreeView.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newViewToolStripMenuItem,
            this.viewToolStripMenuItem1,
            this.openInWindowsExporerToolStripMenuItem,
            this.openTargetProjectFodlerToolStripMenuItem});
            this.contextMenuTreeView.Name = "contextMenuTreeView";
            this.contextMenuTreeView.Size = new System.Drawing.Size(292, 165);
            // 
            // newViewToolStripMenuItem
            // 
            this.newViewToolStripMenuItem.Name = "newViewToolStripMenuItem";
            this.newViewToolStripMenuItem.Size = new System.Drawing.Size(291, 32);
            this.newViewToolStripMenuItem.Text = "New";
            this.newViewToolStripMenuItem.Click += new System.EventHandler(this.newViewToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(291, 32);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // openInWindowsExporerToolStripMenuItem
            // 
            this.openInWindowsExporerToolStripMenuItem.Name = "openInWindowsExporerToolStripMenuItem";
            this.openInWindowsExporerToolStripMenuItem.Size = new System.Drawing.Size(291, 32);
            this.openInWindowsExporerToolStripMenuItem.Text = "Open in Windows Exporer";
            this.openInWindowsExporerToolStripMenuItem.Click += new System.EventHandler(this.openInWindowsExporerToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_icon_black.png");
            this.imageList1.Images.SetKeyName(1, "file_black.png");
            // 
            // menuStrip2
            // 
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fiToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1398, 35);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fiToolStripMenuItem
            // 
            this.fiToolStripMenuItem.Name = "fiToolStripMenuItem";
            this.fiToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fiToolStripMenuItem.Text = "&File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatuslblMain});
            this.statusStrip1.Location = new System.Drawing.Point(0, 802);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1398, 32);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatuslblMain
            // 
            this.StatuslblMain.Name = "StatuslblMain";
            this.StatuslblMain.Size = new System.Drawing.Size(188, 25);
            this.StatuslblMain.Text = "No changes are found";
            // 
            // openTargetProjectFodlerToolStripMenuItem
            // 
            this.openTargetProjectFodlerToolStripMenuItem.Name = "openTargetProjectFodlerToolStripMenuItem";
            this.openTargetProjectFodlerToolStripMenuItem.Size = new System.Drawing.Size(291, 32);
            this.openTargetProjectFodlerToolStripMenuItem.Text = "Open Project Folder";
            this.openTargetProjectFodlerToolStripMenuItem.Click += new System.EventHandler(this.OpenTargetProjectFodlerToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 834);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "GenX Dekstop v0.0.0";
            this.panelMain.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuTreeView.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TreeView treeLibrary;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatuslblMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuTreeView;
        private System.Windows.Forms.ToolStripMenuItem newViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolItemFolder;
        private System.Windows.Forms.ToolStripButton toolItemSolution;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolItemProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolItemFile;
        private System.Windows.Forms.Panel panelManager;
        private System.Windows.Forms.ToolStripMenuItem openInWindowsExporerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTargetProjectFodlerToolStripMenuItem;
    }
}

