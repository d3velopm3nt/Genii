using DALX.Core;
using GENX.Core;
using GENX.Generator.Project;
using GENX.Generator.Solution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALX_UI.Forms
{
    public partial class frmNewFolder : Form
    {
        #region Properties
        private int xType;
        private frmMain frmMain;
        #endregion

        #region Constructors
        public frmNewFolder(int xType,frmMain frm1)
        {
            InitializeComponent();
            this.xType = xType;
            this.frmMain = frm1;
            SetNewText();
        }

        #endregion

        #region Methods
        private void SetNewText()
        {
            switch(this.xType)
            {
                case 1:
                    lblNew.Text = "New Solution";
                    break;
                case 2:
                    lblNew.Text = "New Project";
                    break;
                case 3:
                    lblNew.Text = "New File";
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFolderName.Text == "")
                    throw new Exception("No Folder Name Entered");
                if (xType == 1)
                    SolutionHelper.CreateSolutionFolder(txtFolderName.Text);
                else if (xType == 2)
                {
                    ProjectHelper.CreateProjectFolderWithXFolders(frmMain.SolutionSelected, txtFolderName.Text);
                   
                }
                else if (xType == 3)
                    FileHelper.WriteToFile(frmMain.BuildCurrentPath()+ @"\"+ txtFolderName.Text ,"//Date Createad: " + DateTime.Now);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmNewFolder_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
