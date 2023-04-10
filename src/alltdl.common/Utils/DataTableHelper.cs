using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;

//using System.Linq;
using System.Text;

//using System.Text.Json;

namespace alltdl.Utils
{
    public static class DataTableHelper
    {
        //public static DataTable? ConvertToDataTable(IEnumerable<dynamic> data)
        //{
        //    var json = JsonSerializer.Serialize(data);
        //    return JsonSerializer.Deserialize(json, typeof(DataTable)) as DataTable;
        //}

        /// <summary>
        /// Convert an IEnumerable T to <see cref="DataTable"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns>A <see cref="DataTable"/>.</returns>
        public static DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            var table = new DataTable();

            var properties =
                TypeDescriptor.GetProperties(typeof(T));

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            return table;
        }

        //public static IEnumerable<T> ConvertToList<T>(this DataTable dt)
        //{
        //    return from DataRow row in dt.Rows select getItem<T>(row);
        //}

        /// <summary>
        /// Write the datatable to a CSV file.
        /// </summary>
        /// <param name="dataTable">The DataTable.</param>
        /// <param name="filePath">The file path.</param>
        public static void WriteToCsvFile(this DataTable dataTable, string filePath)
        {
            var sb = new StringBuilder();

            foreach (var col in dataTable.Columns)
            {
                sb.Append(col + ",");
            }

            sb.Replace(",", System.Environment.NewLine, sb.Length - 1, 1);

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                {
                    sb.Append("\"" + column + "\",");
                }

                sb.Replace(",", System.Environment.NewLine, sb.Length - 1, 1);
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        //private static T getItem<T>(DataRow dr)
        //{
        //    var temp = typeof(T);
        //    var obj = Activator.CreateInstance<T>();

        //    foreach (DataColumn column in dr.Table.Columns)
        //    {
        //        foreach (var pro in temp.GetProperties())
        //        {
        //            if (pro.Name == column.ColumnName)
        //                pro.SetValue(obj, dr[column.ColumnName], null);
        //            else
        //                continue;
        //        }
        //    }
        //    return obj;
        //}
    }
}