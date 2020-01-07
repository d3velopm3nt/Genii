
using DALX.Core.Sql.Filters;
using DALX.Core.Sql.Parameters;
using DALX.Core.Sql.Sorters;
using DALX.Mapping;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALX.Core.Sql
{
    public static class DBQueryManager
    {
        #region Properties
        private static SqlDbConnection helper;
        public static SqlDbConnection DBHelper
        {

            get
            {
                if (helper == null)
                helper = new SqlDbConnection();
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

       

        #endregion


        #region Methods
        public static bool Create<T>(T obj,string tableName) where T : class,new()
        {
            try
            {
            string query = QueryBuilder.BuildInsertQuery(tableName, ParameterMapper<T>.Map(obj));
             
                return ExecuteDbQuery(query);
            }
            catch(SqlException ex)
            {
 
                return false;
            }
            catch(Exception ex)
            {
              
                return false;
            }
        }

        public static bool Delete<T>(T obj, string tableName, List<QueryFilter> collection) where T : class, new()
        {
            string query = QueryBuilder.BuildDeleteQuery(tableName, collection);
    
            return ExecuteDbQuery(query);
        }

        public static List<T> Read<T>(string tableName,List<QueryFilter> filters,SorterCollection sorters =null,int selectTop=0) where T : class,new()
        {
            try
            {
            string query = QueryBuilder.BuildSelectQuery(tableName, filters,sorters,selectTop);
        
                DataTable table =  DBHelper.GetDataTable(query);
            return QueryHelper.BuildEntityList<T>(table);

            }
            catch (SqlException ex)
            {
            
                
            }
            catch (Exception ex)
            {

           
            }
            return null;
        }

      

        public static bool GetEntity<T>(this T entity,object ID) where T : class, new()
        {
           return  entity.LoadEntity<T>(ID);           
        }

        public static bool Update<T>(string tableName,DBParameterCollection parameters=null, List<QueryFilter> filters =null) where T : class, new()
        {
            try
            {
                string query =  QueryBuilder.BuildUpdateQuery(tableName, parameters, filters);
              
                  
            return ExecuteDbQuery(query);
            }
            catch (SqlException ex)
            {
                
                return false;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public static  bool  Update(string tableName,string column, string value,int Id)
        {
            try
            {
                string query = $"UPDATE {tableName} SET {column}='{value}' WHERE ID={Id}";
               
               DBHelper.ExecuteQuery(query);
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public static List<T> SelectQuery<T>(string query) where T :class,new()
        {
            return QueryHelper.BuildEntityList<T>(CoreHelper.DBHelper.GetDataTable(query));
        }

        public static List<T> Distinct<T>(string tablename,string identifier) where T : class, new()
        {
            string query = $"SELECT * FROM (SELECT *, ROW_NUMBER() OVER(PARTITION BY {identifier} ORDER BY ID DESC) rownumber FROM [dbo].{tablename}) a WHERE rownumber = 1; ";
            return QueryHelper.BuildEntityList<T>(CoreHelper.DBHelper.GetDataTable(query));
        }

        public static int CheckIfExist( string column,string value,string tableName)
        {
            string query = $"SELECT ID FROM {tableName} WHERE {column}={value}";
            var result =  DBHelper.GetDataTable(query);
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
            bool result =  DBHelper.ExecuteQuery(query);
            return result;
        }

        private static bool LoadEntity<T>(this T entity, object ID) where T : class, new()
        {
            string query = QueryBuilder.BuildSelectOneQuery(entity.GetType().Name, ID);

            var row = DBHelper.GetDataTable(query);
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
