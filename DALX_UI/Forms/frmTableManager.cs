using DALX.Core.Sql;
using GENX.Interfaces;
using GENX.Generator.Library;
using GENX.Generator.Project;
using GENX.Generator.Template;
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
    public partial class frmTableManager : Form
    {
        #region Properties
        private string TableName = "";
        private ProjectFile ProjectFile = null;
        private List<IXFile> FullTemplateList { get; set; }
        private int TemplateRowIndex = 0;
        string TotalColumns_TemplateCol = "Columns";
        string Select_ColumnsCol = "Select";
        #endregion

        #region Constructors

        public frmTableManager(string tableName, ProjectFile projectFile)
        {
            InitializeComponent();
            this.TableName = tableName;
            this.ProjectFile = projectFile;
            LoadManager();
        }
        #endregion

        #region Methods
        public void LoadManager()
        {
            lblTable.Text = "Table - " + TableName;
            FillColumnsDataGrid();
            FillTemplateComboBox();
            dgvColumns.Enabled = false;
        }

        private void FillColumnsDataGrid()
        {
            dgvColumns.Rows.Clear();
            foreach (string column in SqlHelper.SelectColumnsFromTable(TableName))
            {
                dgvColumns.Rows.Add(column,false);
            }
        }

        private void FillTemplateComboBox()
        {
            cbxTemplates.Items.Clear();
            FullTemplateList = LibraryHelper.GetFileXList(GENX.Core.XType.Template, ProjectFile.Path + "\\Templates\\");
            if (FullTemplateList.Count > 0)
            {
                foreach (IXFile template in FullTemplateList)
                {
                    cbxTemplates.Items.Add(template.FileName);
                }
                cbxTemplates.Text = "Please Select";
            }
            else
                cbxTemplates.Text = "No Templates Found";
        }

        private void TickColumnsAddedToTemplate()
        {

            if (ProjectFile.TableList != null && ProjectFile.TableList.Count > 0)
            {
                var columns = ProjectFile.TableList.Where(x => x.TableName == TableName).FirstOrDefault().ColumnList;
                for (int i = 0; i < dgvColumns.RowCount; i++)
                {
                    string col = dgvColumns[0, i].Value.ToString();
                    if (columns.Where(x => x.ColumnName.Contains(col)).Any())
                        dgvColumns[1, i].Value = true;
                    else
                        dgvColumns[1, i].Value = false;
                }
            }
        }

        private void AddRemoveTemplateColumns(bool check)
        {
            for (int i = 0; i < dgvColumns.Rows.Count; i++)
            {
                dgvColumns.Rows[i].Cells[Select_ColumnsCol].Value = check;
            }
            if (check)
                dgvTemplates[TotalColumns_TemplateCol, TemplateRowIndex].Value = dgvColumns.RowCount;
            else
                dgvTemplates[TotalColumns_TemplateCol, TemplateRowIndex].Value = 0;
        }
        #endregion

        #region Form Methods
        private void frmTableManager_Load(object sender, EventArgs e)
        {

        }

        private void cbxAddAllColumns_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAddAllColumns.Checked)
                AddRemoveTemplateColumns(true);
            else
                AddRemoveTemplateColumns(false);

        }

        private void cbxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTemplates.SelectedIndex > -1)
            {
                dgvTemplates.Rows.Add(cbxTemplates.SelectedItem.ToString(), 0);
                TickColumnsAddedToTemplate();
                if(cbxTemplates.Items.Count > 0)
                TemplateRowIndex = cbxTemplates.Items.Count -1;
                dgvColumns.Enabled = true;
            }
        }

        private void dgvColumns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
                

            int colCount = Convert.ToInt32(dgvTemplates[TotalColumns_TemplateCol, TemplateRowIndex].Value);

            if ((bool)dgvColumns[Select_ColumnsCol, e.RowIndex].Value == false)
            {
                if (colCount < dgvColumns.RowCount)
                    colCount += 1;
            }
            else
            {
                if (colCount > 0)
                    colCount -= 1;

            }

            dgvTemplates[TotalColumns_TemplateCol, TemplateRowIndex].Value = colCount;
        }

        private void dgvTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TemplateRowIndex = e.RowIndex;
        }
        #endregion
    }
}
