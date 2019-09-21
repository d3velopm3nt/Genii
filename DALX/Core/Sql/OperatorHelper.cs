using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql
{
    public static class OperatorHelper
    {

        public static string GetFilterOperatorSymbol(FilterOperator filterOperator)
        {
            string returnval = "";
            switch(filterOperator)
            {
                case FilterOperator.Equals:
                    returnval = "=";
                    break;
                case FilterOperator.NotEquals:
                    returnval = "<>";
                    break;
                case FilterOperator.GreaterThan:
                    returnval = ">";
                    break;
                case FilterOperator.GreaterAndEquals:
                    returnval = ">=";
                    break;
                case FilterOperator.LessThan:
                    returnval = "<";
                    break;
                case FilterOperator.LessAndEquals:
                    returnval = "<=";
                    break;
                case FilterOperator.Like:
                    returnval = "LIKE";
                    break;
                case FilterOperator.NotLike:
                    returnval = "NOT LIKE";
                    break;
                case FilterOperator.In:
                    returnval = "IN";
                    break;

            }
            return returnval;
           
        }
    }
}
