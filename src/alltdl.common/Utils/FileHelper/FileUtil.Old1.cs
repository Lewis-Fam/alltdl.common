/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System.Reflection;

namespace alltdl.Utils.fileHelper
{
    public static partial class FileUtil
    {
        public static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}