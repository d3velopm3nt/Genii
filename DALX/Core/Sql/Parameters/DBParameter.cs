using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALX.Core.Sql.Parameters
{
   public class DBParameter
    {
        public string ColumnName { get; set; }
        public object Value { get; set; }

        public string Name { get; set; }
    }
}
