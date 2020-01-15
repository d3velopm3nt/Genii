using GENX.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Files
{
   public class TypescriptFile :FileX
    {
        public TypescriptFile()
        {

        }

        public override string GetDataType(string dbType)
        {
            string datatype = dbType;
            switch (dbType)
            {
                case "uniqueidentifier":
                case "varchar":
                case "nvarchar":
                case "text":
                case "nchar":
                    datatype = "string";
                    break;
                case "bit":
                    datatype = "boolean";
                    break;
                case "timestamp":
                case "datetime":
                case "datetime2":
                    datatype = "Date";
                    break;
                case "real":                 
                case "decimal":
                case "smallint":
                case "bigint":
                    datatype = "number";
                    break;
            }
            return datatype;
        }
    }
}
