using System;
using System.IO;
using System.Reflection;

namespace alltdl.Constants
{
    public static class iLewisDb
    {
        public const string SqliteDbPath = @"Data Source=D:\daddy\dev\.alltdl\data\alltdl.db\alltdl.db3";

        public const string SqliteLifeDbPath = @"Data Source=D:\daddy\.life\db\life.db3";

        public const string SrcDb3 = @"Data Source=lifedb.db3";

        public const string SqliteLifeDbName = @"life.db3";

        public static string SqliteLifeDbConnectionString => @$"Date Source={AssemblyDirectory}\{SqliteLifeDbName}";

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

        public static bool SqliteLifeDbExists()
        {
            return File.Exists(SqliteLifeDbConnectionString);
        }

        private static bool SqliteDbExists()
        {
            return File.Exists(SqliteDbPath);
        }
    }
}