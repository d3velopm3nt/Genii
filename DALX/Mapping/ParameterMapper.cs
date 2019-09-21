using DALC4NET;
using DALX.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;


namespace DALX.Mapping
{
    public static class ParameterMapper<TEntity> where TEntity : class, new()
    {

        private static List<PropertyInfo> GetPropertiesWithDataMapping(PropertyInfo[] properties)
        {
            return properties.Where(
                 prop => Attribute.IsDefined(prop, typeof(DataMapping))).ToList();
        }

        private static List<string> GetSourceNames(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).Where(x => x.GetType() == typeof(DataNamesAttribute)).FirstOrDefault();
            if (property != null)
            {
                return ((DataNamesAttribute)property).ColumnNames;
            }
            return new List<string>();
        }

        public static DBParameterCollection Map(object entity)
        {
            try
            {
                DBParameterCollection collection = new DBParameterCollection();
                var properties = GetPropertiesWithDataMapping((entity.GetType()).GetProperties()).ToList();

                foreach (var prop in properties)
                {
                    var value = prop.GetValue(entity, null);
                    int IntID = 0;
                    if (value != null)
                    {
                        if (prop.Name == "ID")
                            if (int.TryParse(value.ToString(), out IntID))
                            {
                                if (IntID == 0)
                                    continue;
                            }
                            else if (Guid.TryParse(value.ToString(), out Guid result))
                            {
                                if (result == Guid.Empty)
                                    continue;
                            }

                        string fieldName = PropertyMapHelper.GetColumnDataName(entity.GetType(), prop.Name);

                        if (value.ToString() == "0001/01/01 12:00:00 AM")
                            value = new DateTime(1900, 01, 01);
                        var dbParam = new DBParameter()
                        {
                            ColumnName = fieldName,
                            Name = "@" + fieldName,
                            Value = value
                        };
                        collection.Add(dbParam);

                    }
                }
                return collection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
