using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GENX.Generator.Connection;
using GENX.Generator.Project;

namespace DALX_UI.UserControls
{
    public partial class ucSQLConnection : UserControl
    {
        #region Properties
        private frmMain frmMain { get; set; }
        private ucProjectManager ProjectManager { get; set; }
        #endregion
        public ucSQLConnection(frmMain frm,ucProjectManager projectManager)
        {
            InitializeComponent();
            frmMain = frm;
            ProjectManager = projectManager;
            LoadConnectionFile();

        }

        private void cbxAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxAuth.SelectedIndex == 0)
            {
                txtpassword.Enabled = false;
                txtusername.Enabled = false;
            }
            else
            {
                txtpassword.Enabled = true;
                txtusername.Enabled = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDatasource.Text == "")
                    throw new Exception("No Data Source was entered");

                if (txtDatabase.Text == "")
                    throw new Exception("No database was entered");

                if(cbxAuth.SelectedIndex ==1)
                {
                    if (txtusername.Text == "")
                        throw new Exception("No username was entered");

                    if (txtpassword.Text == "")
                        throw new Exception("No password was entered");
                }
                ProjectManager.ProjectFile.DefaultConnection = GetConnectionFile();
                ProjectHelper.CreateFile(ProjectManager.ProjectFile);
                MessageBox.Show("Database connection created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucSQLConnection_Load(object sender, EventArgs e)
        {

        }

        #region Methods
        public ConnectionFile GetConnectionFile()
        {
            var file = new ConnectionFile();

            file.DataSource = txtDatasource.Text;
            file.Database = txtDatabase.Text;
            file.Username = txtusername.Text;
            file.Password = txtpassword.Text;
            file.SqlAuthentication = cbxAuth.SelectedIndex == 1 ? true : false;
            file.FullString = ConnectionHelper.BuildConnectionString(file);
            return file;

        }

        public void LoadConnectionFile()
        {
            var file = ProjectManager.ProjectFile.DefaultConnection;
            txtDatasource.Text = file.DataSource;
            txtDatabase.Text = file.Database;
            txtusername.Text = file.Username;
            txtpassword.Text = file.Password;

            if (file.SqlAuthentication)
                cbxAuth.SelectedIndex = 1;
            else
                cbxAuth.SelectedIndex = 0;
        }
        #endregion
    }
}
