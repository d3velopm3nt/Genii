using GENX.Generator;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Files
{
   public class CSharpFile :FileX
    {
        #region Contructors
        public CSharpFile()
        {
                
        }

        public CSharpFile(IXFile file): base(file)
        {

        }
        #endregion
        public override string CommentLine
        {
            get
            {
                return "//";
            }
        }


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

        public override IXFile Clone()
        {
            return new CSharpFile(this);
        }

    }
}
