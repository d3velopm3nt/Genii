using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql.Filters
{
   public class QueryFilterCollection
    {
        private List<QueryFilter> filterCollection { get; set; }
        public QueryFilterCollection(QueryFilter [] queryFilters)
        {
            filterCollection = queryFilters.ToList();
        }

        public QueryFilterCollection()
        {
            filterCollection = new List<QueryFilter>();
        }

        public void Add(QueryFilter filter)
        {
            this.filterCollection.Add(filter);
        }

        public void Remove(QueryFilter filter)
        {
            this.filterCollection.Remove(filter);
        }

        public List<QueryFilter> FilterList
        {
            get
            {
            return filterCollection;
            }
        }
    }
}
