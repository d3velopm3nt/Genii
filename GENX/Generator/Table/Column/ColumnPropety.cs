using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Table.Column
{
    public class ColumnPropety
    {
        #region Properties
        public string ColumnName { get; set; }
        public string dbType { get; set; }
        public string DataType
        {
            get
            {
                return TableHelper.GetDataTypeFromDbType(dbType);
            }
        }
        public string DefaultValue { get; set; }
        #endregion

        #region Constructors
        public ColumnPropety()
        {

        }
        public  ColumnPropety(string columnName,string dataType,string defaultValue)
        {
            this.ColumnName = columnName;
            this.dbType = dataType;
            this.DefaultValue = defaultValue;
        }
        #endregion
    }
}
