using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetDataExtractorPro
{
    public static class PropertyAccess
    {
        public static object GetNestedPropertyValue(object obj, string propertyPath)
        {
            foreach (var propertyName in propertyPath.Split('.'))
            {
                if (obj == null) return null;
                Type type = obj.GetType();

                // Get property information
                PropertyInfo property = type.GetProperty(propertyName);
                if (property != null && property.CanRead)
                {
                    obj = property.GetValue(obj);
                }
                else
                {
                    return null;
                }
            }
            return obj;
        }
    }
}
