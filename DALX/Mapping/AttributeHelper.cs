using DALX.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Mapping
{
    public static class AttributeHelper
    {
        private static List<string> GetSourceNames(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).Where(x => x.GetType() == typeof(DataNamesAttribute)).FirstOrDefault();
            if (property != null)
            {
                return ((DataNamesAttribute)property).ColumnNames;
            }
            return new List<string>();
        }
    }
}
