

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql
{
    public static class SqlHelper
    {
        public static int GetTableCount(string table)
        {
            string query = "Select count(*) from " + table;
            var result = CoreHelper.DBHelper.GetDataView(query);
            if (result != null)
                return Convert.ToInt32(result[0]);
            else
                return 0;
        }

        public static List<string> SelectAllDatabaseTables()
        {
            var list = new List<string>();
            try
            {
                string query = "Select * FROM INFORMATION_SCHEMA.TABLES";
                var result = CoreHelper.DBHelper.GetDataTable(query);
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    string table = result.Rows[i]["TABLE_NAME"].ToString();
                    list.Add(table);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public static DataView SelectTableRelationships(string TableName)
        {
            //"Select Table_Name FROM INFORMATION_SCHEMA.TABLES where Table_Name in (select Replace(Column_Name, 'ID', '') from INFORMATION_SCHEMA.Columns where TABLE_NAME = '" + TableName + "')";

            string query = "SELECT t.name AS FKTableName , pc.name AS FKColumn, rt.name AS ReferencedTable " +
            "FROM sys.foreign_key_columns AS fkc " +
            "INNER JOIN sys.foreign_keys AS fk ON fkc.constraint_object_id = fk.object_id " +
            "INNER JOIN sys.tables AS t ON fkc.parent_object_id = t.object_id " +
            "INNER JOIN sys.tables AS rt ON fkc.referenced_object_id = rt.object_id " +
            "INNER JOIN sys.columns AS pc ON fkc.parent_object_id = pc.object_id " +
            "  AND fkc.parent_column_id = pc.column_id " +
            "INNER JOIN sys.columns AS c ON fkc.referenced_object_id = c.object_id " +
            "  AND fkc.referenced_column_id = c.column_id " +
            "WHERE t.name = '" + TableName + "'";

            var list = new List<string>();
            try
            {
                return  CoreHelper.DBHelper.GetDataView(query);
              
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static List<string> SelectColumnsFromTable(string TableName)
        {
            string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TableName + "'";
            var list = new List<string>();
            try
            {
                var result = CoreHelper.DBHelper.GetDataView(query);
                for (int i = 0; i < result.Count; i++)
                {
                    string table = result[i].Row["COLUMN_NAME"].ToString();
                    list.Add(table);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
