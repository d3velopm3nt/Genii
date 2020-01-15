using GENX.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Files
{
   public class CSharpFile :FileX
    {
        public override string GetDataType(string dbType)
        {
            string datatype = dbType;
            switch (dbType)
            {
                case "uniqueidentifier":
                    datatype = "Guid?";
                    break;
                case "varchar":
                case "nvarchar":
                case "text":
                case "nchar":
                    datatype = "string";
                    break;
                case "bit":
                    datatype = "bool";
                    break;
                case "timestamp":
                case "datetime":
                case "datetime2":
                    datatype = "DateTime";
                    break;
                case "real":
                    datatype = "decimal";
                    break;
                case "decimal":
                    datatype = "double";
                    break;
                case "smallint":
                case "bigint":
                    datatype = "int";
                    break;
            }
            return datatype;
        }
    }
}
