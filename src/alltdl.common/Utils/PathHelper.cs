using System;
using System.IO;
using System.Reflection;

namespace alltdl.Utils
{
    public static class PathHelper
    {
        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().Location;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path) ?? throw new DirectoryNotFoundException($"The {nameof(AssemblyDirectory)} location was not found.");
            }
        }
    }
}