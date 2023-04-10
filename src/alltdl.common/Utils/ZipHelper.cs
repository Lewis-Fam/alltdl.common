using System;
using System.IO;
using System.IO.Compression;

namespace alltdl.Utils
{
    public class ZipHelper
    {
        public class GZip
        {
            public static void Compress(DirectoryInfo directorySelected)
            {
                var directoryPath = @".\temp";

                foreach (var fileToCompress in directorySelected.GetFiles())
                {
                    using var originalFileStream = fileToCompress.OpenRead();
                    if ((File.GetAttributes(fileToCompress.FullName) &
                         FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (var compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using var compressionStream = new GZipStream(compressedFileStream,
                                CompressionMode.Compress);
                            originalFileStream.CopyTo(compressionStream);
                        }
                        var info = new FileInfo(directoryPath + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                        Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length} to {info.Length} bytes.");
                    }
                }
            }

            public static void Decompress(FileInfo fileToDecompress)
            {
                using var originalFileStream = fileToDecompress.OpenRead();
                var currentFileName = fileToDecompress.FullName;
                var newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
                using var decompressedFileStream = File.Create(newFileName);
                using var decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress);
                decompressionStream.CopyTo(decompressedFileStream);
                Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
            }

            public static void UseageExample()
            {
                var directoryPath = @".\temp";
                var directorySelected = new DirectoryInfo(directoryPath);
                Compress(directorySelected);

                foreach (var fileToDecompress in directorySelected.GetFiles("*.gz"))
                {
                    Decompress(fileToDecompress);
                }
            }
        }

        public static void Compress(string startPath, string zipPath)
        {
            ZipFile.CreateFromDirectory(startPath, zipPath);
        }

        public static void Decompress(string zipPath, string extractPath)
        {
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}