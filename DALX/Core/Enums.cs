using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core
{
    public enum DBQueryType
    {
        Create=0,
        Read=1,
        ReadOne=2,
        Update=3,
        Delete=4
    }


    public enum FilterOperator
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterAndEquals,
        LessAndEquals,
        Like,
        NotLike,
        In
    }

    public enum LogicalOperator
    {
        NONE,
        AND,
        OR,
        NOR
    }

    public enum EntityState
    {
        Active,
        InActive,
        Deleted,
    }

    public enum QuerySortType
    {
        ASC,
        DESC
    }



}
