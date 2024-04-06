using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace alltdl.Utils
{
    public class HttpHelper
    {
        public static async Task DownloadFileAsync(string outputFileName, string downloadUrl)
        {
            try
            {
                using var client = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Get, downloadUrl);
                using var sendTask = await client.GetAsync(downloadUrl);
                using var response = sendTask.EnsureSuccessStatusCode();
                //var cl = response.Content.Headers.ContentLength.GetValueOrDefault();        
                Console.WriteLine("StatusCode: " + response.StatusCode);
                await using var httpStream = await client.GetStreamAsync(downloadUrl);
                await using var fileStream = File.Create(outputFileName);
                using var reader = new StreamReader(httpStream);
                await httpStream.CopyToAsync(fileStream);
                client.Dispose();
                request.Dispose();
                sendTask.Dispose();
                response.Dispose();
                fileStream.Flush();
                reader.Dispose();
                await httpStream.FlushAsync();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex);
                throw;
            }
        }
    }
}
