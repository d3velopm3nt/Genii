using DALC4NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core
{
    public class CoreHelper
    {
        #region Properties
        private static string connString;
        public static string ConnectionString
        {
            get
            {
                return connString;
            }
            set
            {
                connString = value;
            }
        }

        private static string connstringName;

        public static string ConnectionStringName
        {
            get { return connstringName; }
            set { connstringName = value; }
        }

        #endregion
        private static string dbprovider;

        public static string DBProvider
        {
            get { return dbprovider; }

            set { dbprovider = value; }
        }


        private static DBHelper dBHelper;
        public static DBHelper DBHelper
        {
            get
            {
                if (dBHelper == null || ConnectionString != dBHelper.ConnectionString)
                {
                    if (ConnectionString == null || ConnectionString == "")
                    {
                        if (ConnectionStringName != null && ConnectionStringName != "")
                            dBHelper = new DBHelper(ConnectionStringName);
                        else
                            dBHelper = new DBHelper();
                        ConnectionString = dBHelper.ConnectionString;
                    }
                    else
                    {
                        if (DBProvider == null || DBProvider.Equals(""))
                            dBHelper = new DBHelper(ConnectionString, "System.Data.SqlClient");
                        else
                            dBHelper = new DBHelper(ConnectionString, DBProvider);

                    }
                }

                return dBHelper;

            }
        }

        private static string filePath;

        public static string DefaultFilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public static List<string> BasePropertyList()
        {
            return new List<string>()
            {
                "ID",
                "Status"
            };
        }
        
    }
}
