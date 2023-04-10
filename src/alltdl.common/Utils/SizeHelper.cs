using System;
using System.IO;
using System.Linq;

namespace alltdl.Utils
{
    /// <summary>
    /// Size helper class.
    /// </summary>
    public static class SizeHelper
    {
        /// <summary>
        /// File size units.
        /// </summary>
        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }

        public static long GetFolderSize(string path, string ext, bool allDir)
        {
            var option = allDir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            return new DirectoryInfo(path).EnumerateFiles("*" + ext, option).Sum(file => file.Length);
        }

        public static void TEST()
        {
            var folder = @"C:\Users\User\Videos";

            var bytes = GetFolderSize(folder, "mp4", true); //or GetFolderSize(folder, "mp4", false) to get all single folder only
            var totalFileSize = ToSize(bytes);
            Console.WriteLine(totalFileSize);
        }

        public static string ToSize(this long value, SizeUnits unit)
        {
            return (value / (double)Math.Pow(1024, (long)unit)).ToString("0.00");
        }

        public static string ToSize(this long value)
        {
            var unit = 1024;
            if (value < unit) { return $"{value} B"; }

            var exp = (int)(Math.Log(value) / Math.Log(unit));
            return $"{value / Math.Pow(unit, exp):F2} {("KMGTPE")[exp - 1]}B";
        }
    }
}