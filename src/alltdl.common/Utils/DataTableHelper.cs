using System.Text.Json;
using System.ComponentModel;
using System.Data;

namespace alltdl.Utils;

public static class DataTableHelper
{
    public static DataTable? ConvertToDataTable(IEnumerable<dynamic> data)
    {
        var json = JsonSerializer.Serialize(data);
        return JsonSerializer.Deserialize(json, typeof(DataTable)) as DataTable;
    }

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

    public static IEnumerable<T> ConvertToList<T>(this DataTable dt)
    {
        return from DataRow row in dt.Rows select getItem<T>(row);
    }

    private static T getItem<T>(DataRow dr)
    {
        var temp = typeof(T);
        var obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (var pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, dr[column.ColumnName], null);
                else
                    continue;
            }
        }
        return obj;
    }
}