using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace TransformSystemApp
{
    internal static class DataTableExtensions
    {
        public static List<T> ToListof<T>(this DataTable dt)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    Type type = properties.PropertyType;
                    object value = GetValue(dataRow[properties.Name], type);
                    properties.SetValue(instanceOfT, value, null);
                }
                return instanceOfT;
            }).ToList();

            return targetList;
        }
        private static object GetValue(object ob, Type targetType)
        {
            if (targetType == null)
            {
                return null;
            }
            else if (targetType == typeof(String))
            {
                return ob + "";
            }
            else if (targetType == typeof(short))
            {
                short i = 0;
                short.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(long))
            {
                long i = 0;
                long.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(ushort))
            {
                ushort i = 0;
                ushort.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(uint))
            {
                uint i = 0;
                uint.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(ulong))
            {
                ulong i = 0;
                ulong.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(int))
            {
                int i = 0;
                int.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(DateTime))
            {
                DateTime i;
                DateTime.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(bool))
            {
                bool i;
                bool.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(decimal))
            {
                decimal i;
                decimal.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(float))
            {
                float i;
                float.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(byte))
            {
                byte i;
                byte.TryParse(ob + "", out i);
                return i;
            }
            else if (targetType == typeof(sbyte))
            {
                sbyte i;
                sbyte.TryParse(ob + "", out i);
                return i;
            }
            return ob;
        }
    }
 }
