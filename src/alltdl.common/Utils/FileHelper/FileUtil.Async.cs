/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace alltdl.Utils.fileHelper
{
    public static partial class FileUtil
    {
        public static async Task AppendAllLinesAsync(string path, IEnumerable<string> tmp)
        {
            await System.IO.File.AppendAllLinesAsync(path, tmp).ConfigureAwait(false);
        }

        ///<inheritdoc cref="StreamReader.ReadLineAsync"/>
        public static async Task<IList<string>> ReadAllLinesAsync(string path)
        {
            var lines = new List<string>();
            using var sr = new StreamReader(path);
            var line = await sr.ReadLineAsync().ConfigureAwait(false);

            while (line != null)
            {
                lines.Add(line);
                line = await sr.ReadLineAsync().ConfigureAwait(false);
                lines.Add(line);
            }

            return lines;
        }

        public static async Task<IList<string>> ReadAllLinesAsync(string path, string find)
        {
            var lines = new List<string>();
            using var sr = new StreamReader(path);
            var line = await sr.ReadLineAsync().ConfigureAwait(false);

            while (line != null)
            {
                line = await sr.ReadLineAsync().ConfigureAwait(false);
                if (line != null && line.Contains(find))
                    lines.Add(line);
            }

            return lines;
        }

        public static async Task<string> ReadAllTextAsync(string path)
        {
            byte[] result;
            await using (var sourceStream = System.IO.File.Open(path, FileMode.Open))
            {
                result = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length).ConfigureAwait(false);
            }
            return System.Text.Encoding.UTF8.GetString(result);
        }
    }
}