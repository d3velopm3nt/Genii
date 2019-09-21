using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql.Sorters
{
    public class QuerySorter
    {
        #region Properties
        public string ColumnName { get; set; }
        public QuerySortType SortType { get; set; }
        #endregion

        #region Constructor
        public QuerySorter(string column,QuerySortType sortType)
        {
            this.ColumnName = column;
            this.SortType = sortType;
        }

        #endregion

    }
}
