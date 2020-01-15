using GENX.Generator.Table.Column;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Table
{
   public class TableEntity
    {
        #region Properties
        public string TableName { get; set; }
        public List<string> Relationships { get; set; }
        public IXFile File;
        private List<ColumnPropety> columns;
        public List<ColumnPropety> ColumnList
        {
            get
            {
               // if(columns== null)
                columns = TableHelper.GetColumnPropertyList(this,File);

                return columns;
            }
        }
        #endregion

        #region Constructors
        public TableEntity()
        {

        }
        public TableEntity(string tableName)
        {
            this.TableName = tableName;
 
        }
        #endregion
    }
}
