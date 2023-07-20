using System;
using System.IO;

namespace alltdl.Extensions
{
    public static class StreamExtension
    {
        public static string ToBase64String(this Stream stream)
        {
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
}