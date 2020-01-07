
using DALX.Core.Sql;
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


        private static SqlDbConnection dBHelper;
        public static SqlDbConnection DBHelper
        {
            get
            {
                if (dBHelper == null)
                    dBHelper = new SqlDbConnection();

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

        public static List<string> IgnoreList()
        {
            return new List<string>()
            {
                "CreatedDate",
                "UpdatedDate"
            };
        }
        
    }
}
