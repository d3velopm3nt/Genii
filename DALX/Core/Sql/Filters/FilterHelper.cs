using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql.Filters
{
   public class FilterHelper
    {

        public static QueryFilterCollection AddIdEqualsFilter(object ID,QueryFilterCollection filterCollection =null)
        {
            
            QueryFilterCollection collection = new QueryFilterCollection();
            if (filterCollection != null)
                collection = filterCollection;

            collection.Add(new QueryFilter("ID",ID,FilterOperator.Equals));

            return collection;
        }

        public static QueryFilterCollection AddStatusEqualsFilter(string status, QueryFilterCollection filterCollection = null)
        {

            QueryFilterCollection collection = new QueryFilterCollection();
            if (filterCollection != null)
                collection = filterCollection;

            collection.Add(new QueryFilter("Status", status, FilterOperator.Equals));

            return collection;
        }

        public static List<QueryFilter> AddIdAndStatusFilters(object ID,string status,QueryFilterCollection filterCollection = null)
        {
            List<QueryFilter> collection = new List<QueryFilter>();


            collection.Add(new QueryFilter("ID", ID, FilterOperator.Equals));
            collection.Add(new QueryFilter("Status", status, FilterOperator.Equals));

            return collection;
        }
    }
}
