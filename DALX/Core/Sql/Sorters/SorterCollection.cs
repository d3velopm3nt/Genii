using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql.Sorters
{
   public class SorterCollection
    {
        public List<QuerySorter> List { get; }

        public SorterCollection(QuerySorter [] sorters)
        {
            this.List = sorters.ToList();
        }

        public SorterCollection()
        {
            this.List = new List<QuerySorter>();
        }

        public void Add(QuerySorter sorter)
        {
            this.List.Add(sorter);
        }

        public void Remove(QuerySorter sorter)
        {
            this.List.Remove(sorter);
        }

        public List<QuerySorter> GetList()
        {
            return this.List;
        }
    }
}
