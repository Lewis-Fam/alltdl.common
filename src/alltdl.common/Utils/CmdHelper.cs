using System.Diagnostics;
using System.IO;
using System;

namespace alltdl.Utils
{
    public static class CmdHelper
    {
        public static string RunCommand(string commandToRun, string workingDirectory = null)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                workingDirectory = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            }

            var processStartInfo = new ProcessStartInfo()
            {
                FileName = "cmd",
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                WorkingDirectory = workingDirectory
            };

            var process = Process.Start(processStartInfo);
            if (process == null)
            {
                throw new Exception("Process should not be null.");
            }

            process.StandardInput.WriteLine($"{commandToRun} & exit");
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}