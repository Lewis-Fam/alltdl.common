namespace alltdl.Extensions;

public static class TypeExtensions
{
    public class TypeDescription
    {
        public string AssemblyQualifiedName { get; set; }

        public string FullName { get; set; }
    }

    public static TypeDescription GetDescription(this Type type)
    {
        return new TypeDescription
        {
            AssemblyQualifiedName = type.AssemblyQualifiedName,
            FullName = type.FullName
        };
    }
}