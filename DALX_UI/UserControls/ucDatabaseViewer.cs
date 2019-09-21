using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALX.Core.Sql;
using DALX.Core;
using DALX_UI.Forms;
using GENX.Generator.Table;

namespace DALX_UI.UserControls
{
    public partial class ucDatabaseViewer : UserControl
    {
        #region Properties
        private frmMain frmMain { get; set; }
        private ucProjectManager ProjectManager { get; set; }
        private frmTableManager TableManager { get; set; }
        #endregion

        #region Constructors
        public ucDatabaseViewer(frmMain frm,ucProjectManager projectManager)
        {
            InitializeComponent();
            this.frmMain = frm;
            this.ProjectManager = projectManager;
            this.Dock = DockStyle.Fill;
           
        }
        #endregion

        #region Methods
        public void LoadViewer()
        {
            if (this.ProjectManager.ProjectFile.DefaultConnection.FullString != "")
            {
                CoreHelper.ConnectionString = this.ProjectManager.ProjectFile.DefaultConnection.FullString;
                FillTablesDataGridView();
            }
            else
            {
                CoreHelper.ConnectionString = "";
                dgvTables.Rows.Clear();
            }
        }

        public void FillTablesDataGridView()
        {
            try
            {
                dgvTables.Rows.Clear();
                foreach(string table in SqlHelper.SelectAllDatabaseTables())
                {
                    int count = SqlHelper.SelectTableRelationships(table).Count;
                    if (ProjectManager.ProjectFile.TableList.Where(x => x.TableName == table).Any())
                        dgvTables.Rows.Add(table, count, true);
                    else
                        dgvTables.Rows.Add(table, count, false);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<TableEntity> GetTableList()
        {
            List<TableEntity> tableList = new List<TableEntity>();
            for(int i=0;i<dgvTables.Rows.Count;i++)
            {
                if ((bool)dgvTables.Rows[i].Cells[2].Value == true)
                {
                    var table = new TableEntity(dgvTables.Rows[i].Cells[0].Value.ToString());
                    tableList.Add(table);
                }
            }
            return tableList;
        }

        #endregion

        #region Form Methods


        private void dgvTables_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvTables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                var table = dgvTables.Rows[e.RowIndex].Cells[0].Value.ToString();

                TableManager = new frmTableManager(table, ProjectManager.ProjectFile);
                TableManager.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                ProjectManager.SetStatusChangesUpdate();
            }
        }
    }
}
