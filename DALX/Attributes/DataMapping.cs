using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DALX.Attributes
{

  [System.AttributeUsage(System.AttributeTargets.Property)]
   public class DataMapping : System.Attribute
    {
        public bool AllowDatabaseMapping { get; set; }

        public DataMapping(bool allowDatabaseMapping = false)
        {
            this.AllowDatabaseMapping = allowDatabaseMapping;
        }
    }
}
