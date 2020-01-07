using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALX.Core.Sql.Parameters
{
   public class DBParameterCollection
    {
        public List<DBParameter> Parameters;

        public void Add(DBParameter parameter)
        {
            if (!Parameters.Contains(parameter))
                this.Parameters.Add(parameter);
        }

        public void Remove(DBParameter parameter)
        {
            if (Parameters.Contains(parameter))
                this.Parameters.Remove(parameter);
        }
    }
}
