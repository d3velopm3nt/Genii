using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALX.Core
{
   public class AppConfig
    {
        public static string GetConfigurationValue(string key)
        {
            //Refresh the configuration in run time
            ConfigurationManager.RefreshSection("appSettings");
            //return the appsetting value of setting name
            return ConfigurationManager.AppSettings[key];
        }

        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string DefaultConnectionString
        {
            get
            {
                return GetConnectionString(GetConfigurationValue("defaultConnection"));
            }
        }
    }
}
