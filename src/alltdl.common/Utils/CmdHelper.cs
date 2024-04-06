//using System.Diagnostics;
using System.IO;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace alltdl.Utils
{
    public static class CmdLineUtil
    {
        public static string ExecuteCurlDownload(string outputFile, string download)
        {
            var cmd =
                $"curl.exe -o {outputFile} \"{download}\"";

            Debug.WriteLine($"Executing Curl: {cmd}");

            return ExecuteCommand(cmd);
        }

        public static string ExecuteCommand(string commandToRun, string? workingDirectory = null, int milliseconds = 300000, bool redirectOutput = true)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                //workingDirectory = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
                workingDirectory = Directory.GetCurrentDirectory();
                Debug.WriteLine($"Working Directory={workingDirectory}");
            }

            var processStartInfo = new ProcessStartInfo()
            {
                FileName = "cmd",
                RedirectStandardOutput = redirectOutput,
                RedirectStandardInput = true,
                WorkingDirectory = workingDirectory
            };

            var process = Process.Start(processStartInfo);
            if (process == null)
            {
                throw new Exception("Process should not be null.");
            }

            process.StandardInput.WriteLine($"{commandToRun} & exit");

            var output = string.Empty;

            if (redirectOutput)
                output = process.StandardOutput.ReadToEnd();

            process.WaitForExit(milliseconds);

            return output;
        }

        public static async Task<string> RunCommandAsync(string commandToRun, string? workingDirectory = null, int milliseconds = 300000,
            CancellationToken cancellationToken = default, bool redirectOutput = true)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                workingDirectory = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            }

            var processStartInfo = new ProcessStartInfo()
            {
                FileName = "cmd",
                RedirectStandardOutput = redirectOutput,
                RedirectStandardInput = true,
                WorkingDirectory = workingDirectory
            };

            var process = Process.Start(processStartInfo);
            if (process == null)
            {
                throw new Exception("Process should not be null.");
            }

            var output = string.Empty;

            try
            {
                await process.StandardInput.WriteLineAsync($"{commandToRun} & exit");

                if (redirectOutput)
                    output = await process.StandardOutput.ReadToEndAsync();

                //await process.WaitForExitAsync(cancellationToken);
                process.WaitForExit(milliseconds);

            }
            catch (TaskCanceledException e)
            {
                output = e.Message;
            }

            return output;
        }

        
    }
}