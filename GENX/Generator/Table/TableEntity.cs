using DALX.Core.Sql;
using GENX.Generator.Table.Column;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Table
{
   

   public class TableEntity
    {
        #region Properties
        public string TableName { get; set; }
        public List<LinkedProperty> Relationships { get; set; }
        public IXFile File;
        private List<ColumnProperty> columns;
        public List<ColumnProperty> ColumnList
        {
            get
            {
               // if(columns== null)
                columns = TableHelper.GetColumnPropertyList(this,File);

                return columns;
            }
        }
        #endregion

        #region Constructors
        public TableEntity()
        {

        }
        public TableEntity(string tableName)
        {
            this.TableName = tableName;

            this.Relationships = GetTableRelationships();
 
        }
        #endregion
            
        private List<LinkedProperty> GetTableRelationships()
        {
            try
            {
                List<LinkedProperty> list = new List<LinkedProperty>();
                var result = SqlHelper.SelectTableRelationships(this.TableName);
                for (int i = 0; i < result.Count; i++)
                {
                    LinkedProperty property = new LinkedProperty();

                    property.ColumnName = result[i].Row["FKColumn"].ToString();
                    property.TableName = result[i].Row["ReferencedTable"].ToString();
                    list.Add(property);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
