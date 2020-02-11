using GENX.Generator;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Files
{
    public class TypescriptFile : FileX
    {
        public TypescriptFile()
        {

        }

        public TypescriptFile(IXFile file) : base(file)
        {

        }

        private string fileName;
        public override string FileName
        {
            get
            {
                return fileName.ReplaceWithDash().ToLower();
            }
            set
            {
                fileName = value;
            }
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

        public override string GetDefaultValue(string value,string dbType)
        {
            string defaultValue = value;
            switch (dbType)
            {
                case "uniqueidentifier":
                case "varchar":
                case "nvarchar":
                case "text":
                case "nchar":
                    defaultValue = @"""""";
                    break;
                case "bit":
                    defaultValue = value == "1" || value == "true" ? "true" : "false";
                    break;
                case "timestamp":
                case "datetime":
                case "datetime2":
                    defaultValue = "New Date";
                    break;
                case "real":
                case "decimal":
                case "smallint":
                case "bigint":
                    defaultValue = "0";
                    break;
            }
            return defaultValue;
        }
    }
}
