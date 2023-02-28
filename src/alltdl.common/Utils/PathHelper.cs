using System.Reflection;

namespace alltdl.Utils
{
    public static class PathHelper
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().Location;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path) ?? throw new DirectoryNotFoundException($"The {nameof(AssemblyDirectory)} location was not found.");
            }
        }
    }
}