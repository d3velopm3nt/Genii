using DALC4NET;
using DALX.Core.Sql.Filters;
using DALX.Core.Sql.Sorters;
using Innotrack.Logger;
using DALX.Mapping;
using Innotrack.Logger.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql
{
    public static class DBQueryManager
    {
        #region Properties
        private static DBHelper helper;
        public static DBHelper DBHelper
        {

            get
            {
                if (helper == null)
                helper = new DBHelper();
                return helper;
            }
            set
            {
                if (value != null)
                    helper = value;
                else
                    helper = CoreHelper.DBHelper;
            }
        }

        public static LinkedServer LinkedServer { get; set; }

        #endregion


        #region Methods
        public static bool Create<T>(T obj,string tableName) where T : class,new()
        {
            try
            {
            string query = QueryBuilder.BuildInsertQuery(tableName, ParameterMapper<T>.Map(obj));
                LoggerX.WriteDebugLog($"Insert Query: {query}");
                return ExecuteDbQuery(query);
            }
            catch(SqlException ex)
            {
                LoggerX.WriteErrorLog(ex);
                return false;
            }
            catch(Exception ex)
            {
                LoggerX.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool Delete<T>(T obj, string tableName, List<QueryFilter> collection) where T : class, new()
        {
            string query = QueryBuilder.BuildDeleteQuery(tableName, collection);
            LoggerX.WriteDebugLog($"Delete Query: {query}");
            return ExecuteDbQuery(query);
        }

        public static List<T> Read<T>(string tableName,List<QueryFilter> filters,SorterCollection sorters =null,int selectTop=0) where T : class,new()
        {
            try
            {
            string query = QueryBuilder.BuildSelectQuery(tableName, filters,sorters,selectTop);
                LoggerX.WriteDebugLog($"Read Query: {query}");
                DataTable table = DBHelper.ExecuteDataTable(query);
            return QueryHelper.BuildEntityList<T>(table);

            }
            catch (SqlException ex)
            {
                LoggerX.WriteErrorLog(ex);
                
            }
            catch (Exception ex)
            {

                LoggerX.WriteErrorLog(ex);
            }
            return null;
        }

      

        public static bool GetEntity<T>(this T entity,object ID) where T : class, new()
        {
           return entity.LoadEntity<T>(ID);
            
        }

        public static bool Update<T>(string tableName,DBParameterCollection parameters=null, List<QueryFilter> filters =null) where T : class, new()
        {
            try
            {
                string query = QueryBuilder.BuildUpdateQuery(tableName, parameters, filters);
                LoggerX.WriteDebugLog($"Update Query: {query}");
                  
            return ExecuteDbQuery(query);
            }
            catch (SqlException ex)
            {
                LoggerX.WriteErrorLog(ex);
                return false;
            }
            catch (Exception ex)
            {
                LoggerX.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool Update(string tableName,string column, string value,int Id)
        {
            try
            {
                string query = $"UPDATE {tableName} SET {column}='{value}' WHERE ID={Id}";
                LoggerX.WriteDebugLog("Debug: " + query);
                DBHelper.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                LoggerX.WriteErrorLog(ex);
                return false;
            }
        }

        public static List<T> SelectQuery<T>(string query) where T :class,new()
        {
            return QueryHelper.BuildEntityList<T>(CoreHelper.DBHelper.ExecuteDataTable(query));
        }

        public static List<T> Distinct<T>(string tablename,string identifier) where T : class, new()
        {
            string query = $"SELECT * FROM (SELECT *, ROW_NUMBER() OVER(PARTITION BY {identifier} ORDER BY ID DESC) rownumber FROM [dbo].{tablename}) a WHERE rownumber = 1; ";
            return QueryHelper.BuildEntityList<T>(CoreHelper.DBHelper.ExecuteDataTable(query));
        }

        public static int CheckIfExist( string column,string value,string tableName)
        {
            string query = $"SELECT ID FROM {tableName} WHERE {column}={value}";
            var result = DBHelper.ExecuteDataTable(query);
            if (result == null || result.Rows.Count == 0)
                return 0;
            else
                return Convert.ToInt32(result.Rows[0][0]); 
        }

        public static int Count(string tablename)
        {
            string query = $"SELECT COUNT(*) FROM {tablename}";

            var result = DBHelper.ExecuteScalar(query);

            return Convert.ToInt32(result);
        }

        #endregion

        #region Private Methods
        private static bool ExecuteDbQuery(string query)
        {
            int result = DBHelper.ExecuteNonQuery(query);
            return result == 1 ? true : false;
        }

        private static bool LoadEntity<T>(this T entity, object ID) where T : class, new()
        {
            string query = QueryBuilder.BuildSelectOneQuery(entity.GetType().Name, ID);

            var row = DBHelper.ExecuteDataTable(query);
            if (row.Rows.Count > 0)
            {
                QueryHelper.BuildEntity<T>(entity, row.Rows[0]);
                return true;
            }
            else
                return false ;
        }

        #endregion
    }
}
