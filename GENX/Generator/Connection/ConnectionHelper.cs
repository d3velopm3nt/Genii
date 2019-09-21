using DALX.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Connection
{
   public static class ConnectionHelper
    {
      
        public static string BuildConnectionString(ConnectionFile file)
        {
            string text = "Data Source=" + file.DataSource + "; Database=" + file.Database;

            if (!file.SqlAuthentication)
                text += ";Trusted_Connection=true;";
            else
                text += ";User ID=" + file.Username + ";Password=" + file.Password + ";";
            return text;

        }

        public static ConnectionFile LoadConnectionFile(string connString)
        {
            var file = new ConnectionFile();

        
            if(connString != "")
            {
                file.FullString = connString;
                string[] splitString = connString.Split(';');
                file.DataSource = splitString[0].Substring(splitString[0].IndexOf("=") + 1);
                file.Database = splitString[1].Substring(splitString[1].IndexOf("=") + 1);
                if (splitString[2].Contains("User ID"))
                {
                    file.Username = splitString[2].Substring(splitString[2].IndexOf("=") + 1);
                    file.Password = splitString[3].Substring(splitString[3].IndexOf("=") + 1);
                }
                else
                    file.SqlAuthentication = false;


            }
            return file;
        }

    }
}
