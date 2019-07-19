using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace LogicLayerBusiness {
    public static class Tool {


        public static List<T> DataTableToList<T> (this DataTable table) where T : class, new () {
            try {
                List<T> list = new List<T> ();

                foreach (var row in table.AsEnumerable ()) {
                    T obj = new T ();

                    foreach (var prop in obj.GetType ().GetProperties ()) {
                        try {
                            object tmp = null;
                            System.Reflection.PropertyInfo propertyInfo = obj.GetType ().GetProperty (prop.Name);
                            if (propertyInfo.PropertyType == typeof (int?))
                                tmp = ConvertDB<int?> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (int))
                                tmp = ConvertDB<int> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (string))
                                tmp = ConvertDB<string> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (decimal?))
                                tmp = ConvertDB<decimal?> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (decimal))
                                tmp = ConvertDB<decimal> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (byte?))
                                tmp = ConvertDB<byte?> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (byte))
                                tmp = ConvertDB<byte> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (double?))
                                tmp = ConvertDB<double?> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (double))
                                tmp = ConvertDB<double> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (float?))
                                tmp = ConvertDB<float?> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (float))
                                tmp = ConvertDB<float> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (DateTime?))
                                tmp = ConvertDB<DateTime?> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (DateTime))
                                tmp = ConvertDB<DateTime> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (short?))
                                tmp = ConvertDB<short?> (row[prop.Name]);
                            else if (propertyInfo.PropertyType == typeof (short))
                                tmp = ConvertDB<short> (row[prop.Name]);
                            else
                                tmp = Convert.ChangeType (row[prop.Name], propertyInfo.PropertyType);
                            propertyInfo.SetValue (obj, tmp, null);
                        } catch (Exception) {
                            continue;
                        }
                    }

                    list.Add (obj);
                }

                return list;
            } catch {
                return null;
            }
        }

        public static T ConvertDB<T> (object obj) {
            if (obj == null || obj == DBNull.Value) {
                return default (T);
            } else {
                return (T) obj;
            }
        }
    }
}