
using DALX.Core.Sql;
using GENX.Generator.Table.Column;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Table
{
  public static  class TableHelper
    {
        #region Properties

        #endregion

        #region Methods
        private static List<ColumnProperty> columns;
        public static List<ColumnProperty> GetColumnPropertyList(TableEntity table, IXFile file)
        {
            string query = "Select COLUMN_NAME,DATA_TYPE,COLUMN_DEFAULT from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + table.TableName + "'";
            if (columns == null)
                columns = new List<ColumnProperty>();
            else
                columns.Clear();
            foreach (DataRow row in DALX.Core.CoreHelper.DBHelper.GetDataTable(query).Rows)
            {
                columns.Add(new ColumnProperty(
                        row[0].ToString(),  //Column Name
                        row[1].ToString(),  //Data Type
                        row[2].ToString(),  //Default Value
                        table.Relationships.Any(x=>x.ColumnName == row[0].ToString()) ? true : false,
                        table.Relationships.Where(x=>x.ColumnName == row[0].ToString()).FirstOrDefault()?.TableName,
                        file
                        )) ; 
            }
            return columns;
        }
        #endregion
    }
}
