using System.Reflection;

namespace alltdl.Utils;

public static class ObjectExtension
{
    /// <inheritdoc cref="Type.GetProperties()"/>
    public static IEnumerable<PropertyInfo> GetPropertyInfo(this object obj)
    {
        return obj.GetType().GetProperties();
    }

    /// <inheritdoc cref="GetPropertyInfo"/>
    public static IEnumerable<string> GetPropertyNames(this object obj)
    {
        return GetPropertyInfo(obj).Select(s => s.Name);
    }
}