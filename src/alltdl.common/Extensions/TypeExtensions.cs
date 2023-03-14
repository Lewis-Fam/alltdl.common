using System;

namespace alltdl.Extensions
{
    public static class TypeExtensions
    {
        public class TypeDescription
        {
            public string AssemblyQualifiedName { get; set; }

            public string FullName { get; set; }
        }

        public static TypeDescription GetDescription(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return new TypeDescription
            {
                AssemblyQualifiedName = type.AssemblyQualifiedName ?? throw new ArgumentNullException(nameof(type.AssemblyQualifiedName)),
                FullName = type.FullName ?? throw new ArgumentNullException(nameof(type.FullName))
            };
        }
    }
}