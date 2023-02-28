/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System.Text;

namespace alltdl.Utils.fileHelper
{
    public static partial class FileUtil
    {
        public static class Reader
        {
            /// <summary>ReadFileLines</summary>
            /// <param name="path"></param>
            /// <returns></returns>
            /// <exception cref="IOException"></exception>
            /// <exception cref="ObjectDisposedException"></exception>
            /// <exception cref="UnauthorizedAccessException"></exception>
            /// <exception cref="System.Security.SecurityException"></exception>
            public static IEnumerable<string> ReadFileLines(string path)
            {
                //string path = @"c:\MyTest.txt";
                FileInfo fi = new FileInfo(path);

                // Delete the file if it exists.
                //if (!fi.Exists)
                //{
                //    //Create the file.
                //    using (FileStream fs = fi.Create())
                //    {
                //        Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                //        //Add some information to the file.
                //        fs.Write(info, 0, info.Length);
                //    }
                //}

                //Open the stream and read it back.
                using FileStream fs = fi.OpenRead();
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                var rtn = new List<string>();

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                    rtn.Add(temp.GetString(b));
                }

                return rtn;
            }
        }
    }
}