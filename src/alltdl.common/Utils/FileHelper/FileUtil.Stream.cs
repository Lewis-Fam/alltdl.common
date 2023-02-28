using System.Text;

namespace alltdl.Utils.fileHelper
{
    public static partial class FileUtil
    {
        #region Classes

        public static class Stream
        {
            #region Methods

            public static void Save(string path, string contents, FileMode fileMode = FileMode.OpenOrCreate, bool deleteFile = false)
            {
                if (System.IO.File.Exists(path) && deleteFile)
                {
                    System.IO.File.Delete(path);
                }

                //Create the file.
                using var fs = System.IO.File.Open(path, fileMode);
                WriteContents(fs, contents);
            }

            public static async Task SaveAsync(string path, string contents, FileMode fileMode = FileMode.OpenOrCreate, bool deleteFile = false)
            {
                if (System.IO.File.Exists(path) && deleteFile)
                {
                    System.IO.File.Delete(path);
                }

                var bytes = new UTF8Encoding(true).GetBytes(contents);

                await using var fs = System.IO.File.Open(path, fileMode);
                await WriteContentsAsync(fs, bytes);
            }

            #endregion Methods

            private static void WriteContents(System.IO.Stream fs, string value)
            {
                var bytes = new UTF8Encoding(true).GetBytes(value);
                fs.Write(bytes, 0, bytes.Length);
            }

            private static async Task WriteContentsAsync(System.IO.Stream stream, byte[] value)
            {
                stream.Seek(0, SeekOrigin.End);
                await stream.WriteAsync(value, 0, value.Length);
            }
        }

        #endregion Classes
    }
}