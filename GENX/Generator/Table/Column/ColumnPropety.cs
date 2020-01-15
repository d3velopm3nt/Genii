using GENX.Interfaces;
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
        public bool IsLinkedProperty { get; set; }
        private IXFile _file;
        public string DataType
        {
            get
            {
                return _file.GetDataType(dbType);
            }
        }
        public string DefaultValue { get; set; }
        #endregion

        #region Constructors
        public ColumnPropety()
        {

        }
        public  ColumnPropety(string columnName,string dataType,string defaultValue,bool isLinked, IXFile file)
        {
            this.ColumnName = columnName;
            this.dbType = dataType;
            this.DefaultValue = defaultValue;
            this._file = file;
            this.IsLinkedProperty = isLinked;
            
        }
        #endregion
    }
}
