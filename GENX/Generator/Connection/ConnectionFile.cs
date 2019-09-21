using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Connection
{
   public class ConnectionFile
    {
        #region Properties
        public string DataSource { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullString { get; set; } = "";
        public bool SqlAuthentication { get; set; }
        #endregion
    }
}
