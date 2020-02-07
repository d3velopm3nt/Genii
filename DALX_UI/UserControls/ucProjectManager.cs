using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GENX.Generator.Project;
using DALX.Core;
using GENX.Generator.Template;
using GENX.Generator.Table;
using GENX.Generator.Builder;
using GENX.Interfaces;
using GENX.Extensions;
using GENX.Generator.Language;

namespace DALX_UI.UserControls
{
    public partial class ucProjectManager : UserControl, IGenXControl
    {

        #region Properties
        private int GenIndex { get; set; }
        private frmMain frmMain { get; set; }
        private ucSQLConnection SQLConnection { get; set; }
        private ucDatabaseViewer DatabaseViewer { get; set; }
        public ProjectFile ProjectFile { get; set; }

        public List<ExtensionFile> Extensions { get; set; }

        private ExtensionManager _extensionManager { get; set; }
        public bool hasChanges { get; set; }
        public int totalChanges { get; set; }
        public string currentPath { get; set; }
        public string GenerateStatus { get; set; }
        private BuilderManager builderManager;

        private int TemplateRowIndex { get; set; }

        #endregion

        #region Constructors
        public ucProjectManager(frmMain frm)
        {
            InitializeComponent();
            this.frmMain = frm;
            LoadManager();
         
            builderManager = new BuilderManager(this.ProjectFile);
            _extensionManager = new ExtensionManager(this.ProjectFile);
            this.Dock = DockStyle.Fill;
        }

        #endregion

        #region Helper Methods
        public void LoadManager()
        {          
            //Load ProjectFile from projectConfig.gex file
            LoadProjectConfig();
           this.Extensions = ExtensionManager.LoadExtensions(ProjectFile.Path + @"Extensions.genx");
            builderManager = new BuilderManager(this.ProjectFile);
            ExtensionManager.Extensions = this.Extensions;
            //Load SQL Connection control
            if (this.SQLConnection == null)
                this.SQLConnection = new ucSQLConnection(this.frmMain, this);
            else
                this.SQLConnection.LoadConnectionFile();

            //Load DataViewer control
            if (this.DatabaseViewer == null)
                this.DatabaseViewer = new ucDatabaseViewer(this.frmMain, this);

            if (!panelDatabase.Controls.Contains(this.SQLConnection))
                panelDatabase.Controls.Add(SQLConnection);
            //Set the Labels on the header
            SetHeaderText();
            this.LoadExtensionGrid();
        }

        private void LoadProjectConfig()
        {
            if (hasChanges && currentPath != frmMain.BuildCurrentPath())
            {
                this.Cursor = Cursors.WaitCursor;
                AddProjectChanges();
                this.Cursor = Cursors.Default;
            }
            this.ProjectFile = new ProjectFile();
            this.ProjectFile.Path = this.frmMain.BuildCurrentPath();
            this.ProjectFile.ProjectName = this.frmMain.ProjectSelected;
            this.ProjectFile = ProjectHelper.LoadProjectFile(ProjectFile.Path);

            //Load all templates in project file
            this.LoadTemplatesFromPath();


            if (this.ProjectFile.TargetPath != "")
                txtpath.Text = this.ProjectFile.TargetPath;
            this.Cursor = Cursors.Default;
        }

        public void AddProjectChanges()
        {
            if (hasChanges)
            {
                //Add Tables to Project TableList
                ProjectFile.TableList = DatabaseViewer.GetTableList();
                //Add Templates to Project TemplateList
                ProjectFile.TemplateList = GetTemplateList();

                ProjectHelper.CreateFile(ProjectFile);
                //Reset changes
                hasChanges = false;
                frmMain.UpdateStatus("Project up to date");

            }
        }

        private List<IXFile> GetTemplateList()
        {
            var list = new List<IXFile>();
            for (int i = 0; i < dgvTemplates.RowCount; i++)
            {
                if (dgvTemplates.Rows[i].Cells[1].Value != null && dgvTemplates.Rows[i].Cells[1].Value.ToString() != "")
                {
                   string fileExt = dgvTemplates.Rows[i].Cells[0].Value.ToString();
                    IXFile file = LanguageHelper.GetFileFromExtention(fileExt,ProjectFile);
                    file.FileName = fileExt;
                    file.TargetPath = dgvTemplates.Rows[i].Cells[1].Value.ToString();
                    list.Add(file);
                }
            }
            return list;
        }



        public void SetHeaderText()
        {
            this.SetSolutionText();
            this.SetProjectText();
        }

        private void SetSolutionText()
        {
            this.lblSolution.Text = "Solution - " + frmMain.SolutionSelected;
        }

        private void SetProjectText()
        {
            this.lblProject.Text = "Project -  " + frmMain.ProjectSelected;
        }

        private ProjectFile PopulateProjectFile(string targetPath)
        {
            ProjectFile projectFile = new ProjectFile()
            {
                Solution = this.frmMain.SolutionSelected,
                Name = this.frmMain.ProjectSelected,
                Path = this.frmMain.BuildCurrentPath(),
                TargetPath = targetPath
            };
            return projectFile;
        }

        private void LoadTemplatesFromPath()
        {
            string path = "";

            path = ProjectFile.Path + "\\Templates\\";

            var templates = ProjectHelper.GetProjectTemplates(path);

            dgvTemplates.Rows.Clear();
            foreach (string temp in templates)
            {
                IXFile template = ProjectFile.TemplateList.Where(x => x.FileName == temp).FirstOrDefault();
                if (template == null)
                    template = new TemplateFile();
                dgvTemplates.Rows.Add(temp, template.TargetPath);
            }
        }

        public void SetStatusChangesUpdate()
        {
            hasChanges = true;
            btnSaveChanges.Visible = true;
            lblSaveChanges.Visible = true;
            string status = "Changes made to project";
            lblSaveChanges.Text = status;
            frmMain.UpdateStatus(status);

        }

        private void LoadGenerateGridList()
        {
            dgvGenerateFiles.Rows.Clear();
            foreach (IXFile template in ProjectFile.TemplateList)
            {
                foreach (TableEntity table in ProjectFile.TableList)
                {
                    dgvGenerateFiles.Rows.Add(template.FileName, table.TableName);
                }
            }
        }

        private void LoadExtensionGrid()
        {
            dgvExtensions.Rows.Clear();
            foreach(var extension in Extensions)
            {
                dgvExtensions.Rows.Add(extension.FilePath, extension.Extensions.Count.ToString());
            }
        }

        #endregion

        #region Form Methods

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtpath.Text == "")
                    throw new Exception("No path was entered to configure");
                this.ProjectFile.TargetPath = txtpath.Text;
                ProjectHelper.CreateFile(this.ProjectFile);

                btnSavePath.Visible = false;
                txtpath.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnConfigure_Click(object sender, EventArgs e)
        {
            
            string result = FileHelper.BrowseFolderLocation();

            if (result != "0")
            {
                txtpath.Text = result;
                btnSavePath.Visible = true;
                txtpath.Enabled = true;
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            panelDatabase.Controls.Clear();
            panelDatabase.Controls.Add(SQLConnection);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            panelDatabase.Controls.Clear();
            DatabaseViewer.LoadViewer();
            panelDatabase.Controls.Add(DatabaseViewer);

        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            CoreHelper.DefaultFilePath = txtpath.Text;
            string path = FileHelper.BrowseFolderLocation();
            if (path != "0")
            {
                SetStatusChangesUpdate();
                lblTemplatePath.Text = path;
                dgvTemplates.Rows[TemplateRowIndex].Cells[1].Value = path;
            }
        }


        private void dgvTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                TemplateRowIndex = e.RowIndex;
            }

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            AddProjectChanges();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvTemplates.Rows[TemplateRowIndex].Cells[1].Value = "";
            SetStatusChangesUpdate();
        }

        private void toolbuttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGenerateGridList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {           
            this.builderManager.GenerateTemplateTableFiles(this);

            this._extensionManager.RunExtensions();
        }
        #endregion

        #region Interface Methods

        public void GetUpdatedMessageStatus(string template, string table, string result)
        {
            
               // dgvGenerateFiles.Rows[GenIndex].Cells["Temp"].Value.ToString() == template && 
            if (dgvGenerateFiles.Rows[GenIndex].Cells["Table"].Value.ToString() == table)
            {
                dgvGenerateFiles.Rows[GenIndex].Cells["DT"].Value = DateTime.Now;
                dgvGenerateFiles.Rows[GenIndex].Cells["Comment"].Value = result;
                GenIndex += 1;
                if (dgvGenerateFiles.Rows.Count== GenIndex)
                    GenIndex = 0;
            }

        }
        #endregion
    }
}
