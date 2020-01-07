using DALX.Core.Sql;
using DALX.Core.Sql.Filters;
using DALX.Core.Sql.Parameters;
using DALX.Core.Sql.Sorters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core
{
   public interface IEntity<T> where T : class,new()
    {
        object ID { get; set; }
        //DateTime CreatedDateTime { get; set; }
        //DateTime ModifiedDateTime { get; set; }
        string Status { get; set; }
         SqlDbConnection DbHelper { get; set; }

        //CRUD
        bool Create();
        List<T> Read(QueryFilter filter, QuerySorter sorter, int    SelectTop = 0);

        List<T> Read(List<QueryFilter> filterCollection=null, SorterCollection sorters = null, int SelectTop = 0);
       // List<T> Read(QueryFilter filter=null, SorterCollection sorter = null, int SelectTop = 0);
        bool Update(DBParameterCollection parameters =null, QueryFilterCollection filters=null);
        bool Delete();
        int Count();
        //Custom 
        List<T> RawSelect(string query);
         bool Exist(string column, string value);
    }
}
