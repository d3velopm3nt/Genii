using DALC4NET;
using DALX.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DALX.Mapping
{
    public static class PropertyMapHelper
    {
        #region Mapping Methods
        public static void Map(Type type, DataRow row, PropertyInfo prop, object entity)
        {
            try
            {
                List<string> columnNames = GetSourceNames(type, prop.Name);
                if (columnNames.Count > 0)
                {
                    foreach (var columnName in columnNames)
                    {
                        if (row.Table.Columns.Contains(columnName))
                        {
                            var propertyValue = row[columnName];
                            if (propertyValue != null)
                            {
                                ParsePrimitive(prop, entity, propertyValue);
                            }
                        }
                    }
                }
                else
                {
                    var propertyValue = row[prop.Name];
                    if (propertyValue != null)
                    {
                        ParsePrimitive(prop, entity, propertyValue);
                    }
                }
            }
            catch(Exception ex)
            { }

        }

        public static string GetColumnDataName(Type type, string propertyName)
        {
            List<string> columnNames = GetSourceNames(type, propertyName);
            if (columnNames.Count > 0)
            {
                foreach (var columnName in columnNames)
                {
                    if (propertyName.Contains(columnName))
                    {
                        return columnName;
                    }
                }
            }
            return propertyName;
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


        #endregion

        private static void ParsePrimitive(PropertyInfo prop, object entity, object value)
        {
            if (prop.PropertyType == typeof(string))
            {
                prop.SetValue(entity, value.ToString().Trim(), null);
            }
            else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
            {
                if (value == null)
                {
                    prop.SetValue(entity, null, null);
                }
                else
                {
                    prop.SetValue(entity, ParseBoolean(value.ToString()), null);
                }
            }
            else if (prop.PropertyType == typeof(long))
            {
                prop.SetValue(entity, long.Parse(value.ToString()), null);
            }
            else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
            {
                if (value == null)
                {
                    prop.SetValue(entity, null, null);
                }
                else
                {
                    prop.SetValue(entity, int.Parse(value.ToString()), null);
                }
            }
            else if (prop.PropertyType == typeof(decimal))
            {
                prop.SetValue(entity, decimal.Parse(value.ToString()), null);
            }
            else if (prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?))
            {
                double number;
                bool isValid = double.TryParse(value.ToString(), out number);
                if (isValid)
                {
                    prop.SetValue(entity, double.Parse(value.ToString()), null);
                }
            }
            else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(Nullable<DateTime>))
            {
                DateTime date;
                bool isValid = DateTime.TryParse(value.ToString(), out date);
                if (isValid)
                {
                    prop.SetValue(entity, date, null);
                }
                else
                {
                    isValid = DateTime.TryParseExact(value.ToString(), "MMddyyyy", new CultureInfo("en-US"), DateTimeStyles.AssumeLocal, out date);
                    if (isValid)
                    {
                        prop.SetValue(entity, date, null);
                    }
                }
            }
            else if (prop.PropertyType == typeof(Guid))
            {
                bool isValid = false;
                Guid guid = Guid.Empty;
                try
                {
                    guid = new Guid(value.ToString());
                    isValid = true;
                }
                catch
                {

                }
                if (isValid)
                {
                    prop.SetValue(entity, guid, null);
                }
            }
            else if (prop.PropertyType == typeof(object))
            {
                prop.SetValue(entity, value, null);
            }
        }

        public static bool ParseBoolean(object value)
        {
            if (value == null || value == DBNull.Value) return false;

            switch (value.ToString().ToLowerInvariant())
            {
                case "1":
                case "y":
                case "yes":
                case "true":
                    return true;

                case "0":
                case "n":
                case "no":
                case "false":
                default:
                    return false;
            }
        }
    }
}
