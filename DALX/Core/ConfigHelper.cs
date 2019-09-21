using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core
{
   public class ConfigHelper
    {
        public static string GetConnectionStringByName(string name)
        {
           return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        }
    }
}
