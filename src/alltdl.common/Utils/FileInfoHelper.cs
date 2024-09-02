using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltdl.Utils
{
    public partial class FileInfoHelper
    {
        public static IEnumerable<FileInfo> GetFiles(string path, string searchPattern)
        {
            var pending = new Stack<string>();
            pending.Push(path);

            while (pending.Count != 0)
            {
                path = pending.Pop();
                string[]? next = null;
                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch
                {
                    // ignored
                }

                if (next != null && next.Length != 0)
                    foreach (var file in next)
                        yield return new FileInfo(file);
                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next)
                        pending.Push(subdir);
                }
                catch
                {
                    // ignored
                }
            }
        }

        public static string GetUniqueFileName(string filePath)
        {
            int count = 1;
            string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);
            string newPath = filePath;

            while (File.Exists(newPath))
            {
                string tempFileName = $"{fileNameOnly} ({count}){extension}";
                newPath = Path.Combine(Path.GetDirectoryName(filePath), tempFileName);
                count++;
            }

            return newPath;
        }

    }
}
