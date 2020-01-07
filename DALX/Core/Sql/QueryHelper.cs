
using DALX.Core.Sql.Filters;
using DALX.Core.Sql.Sorters;
using DALX.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql
{
    public static class QueryHelper
    {
        #region Properties

        #endregion

        #region Methods
        internal static string BuildFilters(List<QueryFilter> filters, bool update = false)
        {
            string filterString = "";

            foreach (QueryFilter filter in filters)
            {
                bool check = true;
                if (filter.FilterColumn == "ID" && update)
                    check = false;

                if (check)
                {

                    filterString += filter.FilterColumn + " " + OperatorHelper.GetFilterOperatorSymbol(filter.FilterOperator) + " '" + filter.FilterValue + "'";
                    if (filter.LogicalOperator != LogicalOperator.NONE)
                        if (filter != filters.Last())
                            filterString += " " + filter.LogicalOperator.ToString() + " ";
                }


            }
            return filterString;
        }

        internal static string BuildSorter(SorterCollection sorters)
        {
            var sortString = "";
            foreach (QuerySorter sort in sorters.List)
            {
                if (sortString != "")
                    sortString += ",";
                sortString += sort.ColumnName + " " + sort.SortType.ToString();
            }
            return sortString;
        }

        public static List<T> BuildEntityList<T>(DataTable table) where T : class, new()
        {
            try
            {
                DataMapper<T> mapper = new DataMapper<T>();
                var list = mapper.Map(table);
                return list.ToList();
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        internal static T BuildEntity<T>(this T entity, DataRow row) where T : class, new()
        {
            try
            {
                DataMapper<T> mapper = new DataMapper<T>();
                entity = mapper.Map(row, entity);
                return entity;
            }
            catch (Exception ex)
            {
              
                return null;
            }
        }


        #endregion
    }
}
