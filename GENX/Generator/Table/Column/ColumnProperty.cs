using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Table.Column
{

    public class ColumnProperty
    {
        #region Properties
        public string ColumnName { get; set; }
        public string dbType { get; set; }
        public bool IsLinkedProperty { get; set; }
        public string LinkedTable { get; set; }
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
        public ColumnProperty()
        {

        }
        public  ColumnProperty(string columnName,string dataType,string defaultValue,bool isLinked,string linkedTable, IXFile file)
        {
            this.ColumnName = columnName;
            this.dbType = dataType;
            this.DefaultValue = defaultValue;
            this._file = file;
            this.LinkedTable = linkedTable;
            this.IsLinkedProperty = isLinked;
            
        }
        #endregion
    }
}
