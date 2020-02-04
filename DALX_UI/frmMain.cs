using DALX.Core;
using DALX_UI.Forms;
using DALX_UI.UserControls;
using GENX.Core;
using GENX.Generator.Library;
using GENX.Generator.Solution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALX_UI
{
    public partial class frmMain : Form
    {

        #region Properties
        Generator Core { get; set; }
        public string SolutionSelected { get; set; }
        public string ProjectSelected { get; set; }
        public string XFolderSelected { get; set; }
        public string XFileSelected { get; set; }
        public string XFileText { get; set; }
        public int CurrentSelectedNodeIndex { get; set; }
        public string CurrentSelectNodeText { get; set; }

        #endregion

        #region Constructors
        public frmMain()
        {
            InitializeComponent();
            LoadCoreComponents();
            BuildTreeView();
        }
        #endregion

        #region User Controls
        private ucTextEditor TextEditor { get; set; }
        private ucSolutionManager SolutionManager { get; set; }
        private ucProjectManager ProjectManager { get; set; }
        #endregion

        #region Core
        private void LoadCoreComponents()
        {
            if (Core == null)
                Core = new Generator();
            else
                Core.Load();
        }

        public string BuildCurrentPath()
        {

            string path = SolutionHelper.GetFullPath;
            if (!string.IsNullOrEmpty(SolutionSelected))
                path += SolutionSelected;
            if (!string.IsNullOrEmpty(ProjectSelected))
                path += "\\" + ProjectSelected;
            if (!string.IsNullOrEmpty(XFolderSelected))
                path += "\\" + XFolderSelected;
            if (!string.IsNullOrEmpty(XFileSelected))
                path += "\\" + XFileSelected;
            return path;
        }
        #endregion

        #region Context Menu

        public void CreateNewSelected()
        {
            try
            {
                frmNewFolder frmNew = new frmNewFolder(CurrentSelectedNodeIndex, this);
                frmNew.ShowDialog();

                BuildTreeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void newViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewSelected();
        }

        private void openInWindowsExporerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", BuildCurrentPath());
        }

        private void OpenTargetProjectFodlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe",ProjectManager.ProjectFile.TargetPath);
        }
        #endregion

        #region Nav Menu

        private void SetSolution(string name)
        {
            toolItemSolution.Text = name;
            toolItemProject.Visible = false;
            toolItemFolder.Visible = false;
            toolItemFile.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;
            SolutionSelected = name;
            ProjectSelected = "";
            XFolderSelected = "";
            XFileSelected = "";

            if (SolutionManager == null)
                SolutionManager = new ucSolutionManager(this);
            else
                SolutionManager.SetSolutionText();

            if (!this.panelManager.Controls.Contains(SolutionManager))
            {
                this.panelManager.Controls.Clear();
                this.panelManager.Controls.Add(SolutionManager);
            }
           


        }

        private void SetProject(string name)
        {
            toolItemProject.Text = name;
            toolItemProject.Visible = true;
            toolItemFolder.Visible = false;
            toolItemFile.Visible = false;
            toolStripSeparator3.Visible = true;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;
            ProjectSelected = name;
            XFolderSelected = "";
            XFileSelected = "";

            if (ProjectManager == null)
                ProjectManager = new ucProjectManager(this);
            else
                ProjectManager.LoadManager();

            if (!this.panelManager.Controls.Contains(ProjectManager))
            {
                this.panelManager.Controls.Clear();
                this.panelManager.Controls.Add(ProjectManager);
            }
        }

        private void SetXFolder(string name)
        {
            toolItemFolder.Text = name;
            toolItemFolder.Visible = true;
            toolStripSeparator4.Visible = true;
            toolStripSeparator5.Visible = false;
            XFolderSelected = name;
            XFileSelected = "";
        }

        private void SetXFile(string name)
        {
            toolItemFile.Text = name;
            toolItemFile.Visible = true;
            toolStripSeparator5.Visible = true;
            XFileSelected = name;
        }

        private void BuildMenu(TreeNode node)
        {
            CurrentSelectedNodeIndex = node.Level;
            if (node.Level == 2)
            {
                SetSolution(node.Text);
                
            }
            else if (node.Level == 3)
            {
                SetSolution(node.Parent.Text);
                SetProject(node.Text);

            }
            else if (node.Level == 4)
            {
                SetSolution(node.Parent.Parent.Text);
                SetProject(node.Parent.Text);
                SetXFolder(node.Text);
            }
            else if (node.Level == 5)
            {
                SetSolution(node.Parent.Parent.Parent.Text);
                SetProject(node.Parent.Parent.Text);
                SetXFolder(node.Parent.Text);
                SetXFile(node.Text);
            }
        }


        #endregion

        #region Tree View

        private void OpenTextEditor(TreeNode node)
        {
            if (node.Text.Contains("."))
            {
                this.panelManager.Controls.Clear();
                if (TextEditor == null)
                {
                    TextEditor = new ucTextEditor(this);
                    this.panelManager.Controls.Add(TextEditor);
                }
                else
                {
                    this.TextEditor.OpenFiles(new string []{ BuildCurrentPath()});
                    this.panelManager.Controls.Add(TextEditor);
                }
            }

        }

        private void treeLibrary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
               
                this.CurrentSelectNodeText = e.Node.Text;
                //Build the Nav Menu
                BuildMenu(e.Node);
                //Open Text Editor
                OpenTextEditor(e.Node);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuildTreeView()
        {
            try
            {
                treeLibrary.Nodes.Clear();
                var rootDirectoryInfo = new DirectoryInfo(LibraryHelper.LibraryPath);
                treeLibrary.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
            {
                TreeNode treeNode = new TreeNode(file.Name);
                treeNode.ImageIndex = 1;
                treeNode.SelectedImageIndex = 1;
                directoryNode.Nodes.Add(treeNode);
            }
            return directoryNode;
        }

        private void treeLibrary_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Level == 1)
                    contextMenuTreeView.Items[0].Text = "New Solution";
                else if (e.Node.Level == 2)
                    contextMenuTreeView.Items[0].Text = "New Project";
                else
                {
                    CurrentSelectedNodeIndex = 3;
                    contextMenuTreeView.Items[0].Text = "New File";
                }

                contextMenuTreeView.Show();
            }
        }
        #endregion

        #region Status Update
        public void UpdateStatus(string status)
        {
            StatuslblMain.Text = status;
        }

        #endregion


    }
}
