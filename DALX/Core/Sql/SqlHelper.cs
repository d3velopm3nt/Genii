

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
            var result = CoreHelper.DBHelper.ExecuteDataSet(query);
            if (result != null)
                return Convert.ToInt32(result.Tables[0].DefaultView[0].Row[0]);
            else
                return 0;
        }

        public static List<string> SelectAllDatabaseTables()
        {
                var list = new List<string>();
            try
            {
                string query = "Select * FROM INFORMATION_SCHEMA.TABLES";
                var result = CoreHelper.DBHelper.ExecuteDataSet(query).Tables[0].DefaultView;
                for (int i = 0; i < result.Count; i++)
                {
                    string table = result[i].Row["TABLE_NAME"].ToString();
                    list.Add(table);
                }
            return list;
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
            
        }

        public static List<string> SelectTableRelationships(string TableName)
        {
            string query = "Select Table_Name FROM INFORMATION_SCHEMA.TABLES where Table_Name in (select Replace(Column_Name, 'ID', '') from INFORMATION_SCHEMA.Columns where TABLE_NAME = '" + TableName + "')";

            var list = new List<string>();
            try
            {
                var result = CoreHelper.DBHelper.ExecuteDataSet(query).Tables[0].DefaultView;
                for (int i = 0; i < result.Count; i++)
                {
                    string table = result[i].Row["TABLE_NAME"].ToString();
                    list.Add(table);
                }
                return list;
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
                var result = CoreHelper.DBHelper.ExecuteDataSet(query).Tables[0].DefaultView;
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
