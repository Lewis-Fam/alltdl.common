using System;

namespace alltdl.Attributes
{
    //https://learn.microsoft.com/en-us/dotnet/standard/attributes/retrieving-information-stored-in-attributes
    //https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/attribute-tutorial?source=recommendations
    public static class AttributeHelper
    {
        public static void GetAttribute(Type t)
        {
            // Get instance of the attribute.
            DeveloperAttribute MyAttribute =
                (DeveloperAttribute)Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute));

            if (MyAttribute == null)
            {
                Console.WriteLine("The attribute was not found.");
            }
            else
            {
                // Get the Name value.
                Console.WriteLine("The Name Attribute is: {0}.", MyAttribute.Name);
                // Get the Level value.
                Console.WriteLine("The Level Attribute is: {0}.", MyAttribute.Level);
                // Get the Reviewed value.
                Console.WriteLine("The Reviewed Attribute is: {0}.", MyAttribute.Reviewed);
            }
        }

        public static void GetMultipleAttributes(Type t)
        {
            DeveloperAttribute[] MyAttributes =
                (DeveloperAttribute[])Attribute.GetCustomAttributes(t, typeof(DeveloperAttribute));

            if (MyAttributes.Length == 0)
            {
                Console.WriteLine("The attribute was not found.");
            }
            else
            {
                for (int i = 0; i < MyAttributes.Length; i++)
                {
                    // Get the Name value.
                    Console.WriteLine("The Name Attribute is: {0}.", MyAttributes[i].Name);
                    // Get the Level value.
                    Console.WriteLine("The Level Attribute is: {0}.", MyAttributes[i].Level);
                    // Get the Reviewed value.
                    Console.WriteLine("The Reviewed Attribute is: {0}.", MyAttributes[i].Reviewed);
                }
            }
        }
    }
}