
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
        private static List<ColumnPropety> columns;
        public static List<ColumnPropety> GetColumnPropertyList(TableEntity table, IXFile file)
        {
            string query = "Select COLUMN_NAME,DATA_TYPE,COLUMN_DEFAULT from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + table.TableName + "'";
            if (columns == null)
                columns = new List<ColumnPropety>();
            else
                columns.Clear();
            foreach (DataRow row in DALX.Core.CoreHelper.DBHelper.GetDataTable(query).Rows)
            {
                columns.Add(new ColumnPropety(
                        row[0].ToString(),  //Column Name
                        row[1].ToString(),  //Data Type
                        row[2].ToString(),  //Default Value
                       table.Relationships.Contains(row[0].ToString()) ? true : false,
                        //CheckIfPropertyLinked(table.Relationships, row[0].ToString()),
                        file
                        )) ; ;
            }
            return columns;
        }

        public static string GetDataTypeFromDbType(string dbType)
        {
            string datatype = dbType;
            switch(dbType)
            {
                case "uniqueidentifier":
                    datatype = "Guid";
                    break;
                case "varchar":
                case "nvarchar":
                case "text":
                case "nchar":
                    datatype = "string";
                    break;
                case "bit":
                    datatype = "bool";
                    break;
                case "timestamp":
                case "datetime":
                    datatype = "DateTime";
                    break;
                case "real":
                    datatype = "decimal";
                break;
                case "decimal":
                datatype = "double";
                break;
                case "smallint":
                case "bigint":
                datatype = "int";
                    break;
            }
            return datatype;
        }
        #endregion
    }
}
