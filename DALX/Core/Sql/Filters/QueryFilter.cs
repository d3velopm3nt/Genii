using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql.Filters
{
   public class QueryFilter
    {
        #region Properties
        public string FilterColumn { get; set; }
        public object FilterValue { get; set; }
        public FilterOperator FilterOperator { get; set; }
        public LogicalOperator LogicalOperator { get; set; } = LogicalOperator.NONE;

        #endregion

        #region Constructors
        public QueryFilter()
        {

        }

        public QueryFilter(string column, object value, FilterOperator filterOperator)
        {
            this.FilterColumn = column;
            this.FilterValue = value;
            this.FilterOperator = filterOperator;
        }

        public QueryFilter(string column,object value,FilterOperator filterOperator,LogicalOperator logicalOperator)
        {
            this.FilterColumn = column;
            this.FilterValue = value;
            this.FilterOperator = filterOperator;
            this.LogicalOperator = logicalOperator; 

        }
        #endregion
    }
}
