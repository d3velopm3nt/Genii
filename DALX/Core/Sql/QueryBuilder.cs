
using DALX.Core.Sql.Filters;
using DALX.Core.Sql.Parameters;
using DALX.Core.Sql.Sorters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql
{
    public static class QueryBuilder
    {
        #region Properties

        #endregion

        #region Builder Methods 
        /// <summary>
        /// This is an internal method that builds a SELECT statement to SQL database
        /// </summary>
        /// <returns></returns>
        internal static string BuildSelectQuery(string tableName, List<QueryFilter> filters, SorterCollection sorters, int SelectTop)
        {
           
            tableName = $"[{tableName}]";
            string query = SelectTop == 0 ? "SELECT * FROM " + tableName : "SELECT TOP " + SelectTop + " * FROM " + tableName;
            //Check if there are parameters to add to query
            if (filters != null && filters.Any())
                query += " WHERE " + QueryHelper.BuildFilters(filters);

            //Check if sort need to be added to the query
            if (sorters != null && sorters.List.Any())
                query += " ORDER BY " + QueryHelper.BuildSorter(sorters);
            //   LoggerX.WriteEventLog("DALX: Select Query: " + query);
            return query;
        }

        private static string BuildSelectQueryText(string tableName, List<QueryFilter> filters, SorterCollection sorters, int SelectTop, string Selector)
        {
            tableName = $"[{tableName}]";
            if (Selector == "")
                Selector = "*";               

            string query = SelectTop == 0 ? "SELECT " + Selector +" FROM " + tableName : "SELECT TOP " + SelectTop + " " + Selector +" FROM " + tableName;
            //Check if there are parameters to add to query
            if (filters != null && filters.Any())
                query += " WHERE " + QueryHelper.BuildFilters(filters);

            //Check if sort need to be added to the query
            if (sorters != null && sorters.List.Any())
                query += " ORDER BY " + QueryHelper.BuildSorter(sorters);

            return query;
        }

        /// <summary>
        /// This is an internal method that builds a SELECT statement to SQL database
        /// </summary>
        /// <returns></returns>
        internal static string BuildSelectOneQuery(string tableName, object ID)
        {
            //if (LinkedServer != null)
            //    tableName = LinkedServer.GetLinkedTable(tableName);
            tableName = $"[{tableName}]";
            string query = "SELECT * FROM " + tableName;
            query += " WHERE ID = '" + ID + "'";
            return query;
        }

        /// <summary>
        /// This method builds the Insert Statement to execute
        /// 1. Check if value is not null then add the columnName
        /// 2. Check if value is not null then add the value
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal static string BuildInsertQuery(string tableName, DBParameterCollection parameters)
        {
            
            tableName = $"[{tableName}]";

            if (parameters == null)
                return "No Parameters to Insert";
            string query = "INSERT INTO " + tableName + "(";
            //Adding the columns to insert data in query
            bool added = false;
            for (int i = 0; i < parameters.Parameters.Count; i++)
            {
                DBParameter param = parameters.Parameters[i];
                if (param.Value != null)
                {
                    //Check if a parameter is added then add a comma to the query
                    if (added)
                        if (i < parameters.Parameters.Count)
                            query += ",";
                    //Add the the ColumnName to the query
                    query += param.ColumnName;

                    added = true;
                }
            }

            query += ") VALUES (";
            added = false;
            ///Adding the parameter names to insert in query
            for (int i = 0; i < parameters.Parameters.Count; i++)
            {
                DBParameter param = parameters.Parameters[i];
                if (param.Value != null)
                {
                    //Check if a value is added then add the comma to the query
                    if (added)
                        if (i < parameters.Parameters.Count)
                            query += ",";

                    query += "'" + DBFormatHelper.FixSingleQuotesInText(param.Value.ToString()) + "'";

                    added = true;
                }
            }
            query += ")";
            return query;
        }

        /// <summary>
        /// Build the Update Query with all the parameter and filter collections that are passed in
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="parameters"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        internal static string BuildUpdateQuery(string tableName, DBParameterCollection parameters = null, List<QueryFilter> filters = null)
        {
            tableName = $"[{tableName}]";
            string query = "UPDATE " + tableName + " SET ";
            var paramList = parameters.Parameters.Where(x => x.Value != null && x.ColumnName != "ID").ToList();

            foreach (DBParameter param in paramList)
            {
                query += param.ColumnName + "=";
                //if (param.Value.ToString().All(char.IsDigit) && param.Value.ToString() != "")
                //    query += param.Value;
                //else
                    query += "'" + DBFormatHelper.FixSingleQuotesInText(param.Value.ToString()) + "'";

                if (param != paramList.Last())
                    query += ",";

            }
            if (filters != null && filters.Any())
                query += " WHERE " + QueryHelper.BuildFilters(filters);

            return query;
        }
        /// <summary>
        /// Build the Delete Query with all given query filters
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        internal static string BuildDeleteQuery(string tableName, List<QueryFilter> filters)
        {
            tableName = $"[{tableName}]";
            string query = "DELETE FROM " + tableName;
            if(filters != null && filters.Count > 0)
            query += " WHERE " + QueryHelper.BuildFilters(filters);
            return query;

        }


        internal static string BuildSelectDistinctQuery(string tableName, List<QueryFilter> filters, SorterCollection sorters, int SelectTop, string Selecor)
        {
            return BuildSelectQueryText(tableName,filters,sorters,SelectTop,Selecor);
        }
        #endregion
    }
}