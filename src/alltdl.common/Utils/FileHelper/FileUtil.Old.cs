/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace alltdl.Utils.fileHelper
{
    public static partial class FileUtil
    {
        public static void AppendAllLines(string path, IEnumerable<string> tmp)
        {
            System.IO.File.AppendAllLines(path, tmp);
        }

        public static string ReadAllBytesToString(string fileName, bool fromTop, int count)
        {
            var bytes = System.IO.File.ReadAllBytes(fileName);
            if (fromTop)
            {
                return Encoding.UTF8.GetString(bytes, 0, count);
            }
            return Encoding.UTF8.GetString(bytes, bytes.Length - count, count);
        }

        public static string ReadStreamToString(string file)
        {
            using (var sr = new StreamReader(file))
            {
                return sr.ReadToEnd();
            }
        }

        //public static string ReadAllLines(string fileName, bool fromTop, int count)
        //{
        //    var lines = File.ReadAllLines(fileName);
        //    if (fromTop)
        //    {
        //        return string.Join(Environment.NewLine, lines.Take(count));
        //    }
        //    return string.Join(Environment.NewLine, lines.Reverse().Take(count));
        //}
        public static void WriteAllText(string path, string contents)
        {
            System.IO.File.WriteAllText(path, contents);
        }

        private static Tuple<string, string> MakeError()
        {
            return Tuple.Create("\0", "\0");
        }
    }

    public class FileHelperUtil : FileUtilBase
    {
        public FileHelperUtil(string filename) : base(filename)
        {
        }
    }

    public abstract class FileUtilBase
    {
        protected FileUtilBase()
        {
        }

        protected FileUtilBase(string filename)
        {
            FileInfo = new FileInfo(filename);
        }

        public FileInfo FileInfo { get; protected set; }
    }

    public class FileWatcherUtil
    {
        public FileWatcherUtil()
        {
            _path = "logs";
            DirMonitor();
        }

        private static string _path;

        private FileSystemWatcher _fileSystemWatcher;

        public void DirMonitor(string path = null)
        {
            if (path != null)
                _path = path;

            Debug.WriteLine(_path);

            if (Directory.Exists(_path))
            {
                if (_fileSystemWatcher == null)
                {
                    _fileSystemWatcher = new FileSystemWatcher
                    {
                        Path = _path,
                        EnableRaisingEvents = true
                    };
                    _fileSystemWatcher.Changed += FileWatcher_IsChanged;
                }
            }
        }

        private static void FileWatcher_IsChanged(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine(e.ToJson());
        }
    }
}