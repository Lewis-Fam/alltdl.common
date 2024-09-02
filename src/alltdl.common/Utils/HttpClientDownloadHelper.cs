using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace alltdl.Utils
{
    public class HttpClientDownloadHelperUsage
    {
        async Task Example(string downloadFileUrl, string destinationFilePath)
        {
            //downloadFileUrl = "http://example.com/file.zip";
            destinationFilePath = Path.GetFullPath(destinationFilePath);

            using (var client = new HttpClientDownloadHelper(downloadFileUrl, destinationFilePath))
            {
                client.ProgressChanged += (totalFileSize, totalBytesDownloaded, progressPercentage) =>
                {
                    Console.WriteLine($"{progressPercentage}% ({totalBytesDownloaded}/{totalFileSize})");
                };

                await client.StartDownload();
            }
        }
    }

    public class WebClientDownloadHelper
    {
        public static async Task DownloadWebClient(string requestUri, string savePath)
        {
            using var client = new WebClient();
            client.DownloadFileCompleted += (s, e) => Console.WriteLine("Download file completed.");
            client.DownloadProgressChanged += (s, e) =>
            {
                if (e.ProgressPercentage % 2 == 0 && e.ProgressPercentage > 0)
                    Console.WriteLine($"Downloading {e.ProgressPercentage}%");
            };
            await client.DownloadFileTaskAsync(new Uri(requestUri), savePath);
        }
    }

    public class HttpClientDownloadHelper : IDisposable
    {
        private readonly string _downloadUrl;
        private readonly string _destinationFilePath;

        private readonly HttpClient? _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public delegate void ProgressChangedHandler(long? totalFileSize, long totalBytesDownloaded, double? progressPercentage);

        public event ProgressChangedHandler ProgressChanged;

        public HttpClientDownloadHelper(string downloadUrl, string destinationFilePath)
        {
            _downloadUrl = downloadUrl;
            _destinationFilePath = destinationFilePath;
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromDays(1)
            };
        }

        public HttpClientDownloadHelper(IHttpClientFactory httpClientFactory, string downloadUrl, string destinationFilePath)
        {
            _httpClientFactory = httpClientFactory;
            _downloadUrl = downloadUrl;
            _destinationFilePath = destinationFilePath;
        }

        public async Task StartDownload(bool addUserAgent = true)
        {
            //_httpClient = new HttpClient
            //{
            //    Timeout = TimeSpan.FromDays(1)
            //};
            var ishttpNull = _httpClient == null;
            Console.WriteLine(ishttpNull);
            using var httpClient = _httpClient ?? _httpClientFactory.CreateClient();
            {

                
                    if (addUserAgent)
                        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.0.0 Safari/537.36");

                    using (var response = await httpClient.GetAsync(_downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                    {
                        if (response.IsSuccessStatusCode)
                            await DownloadFileFromHttpResponseMessage(response);
                    }
                
            }
        }

        public async Task StartDownloadOld(bool addUserAgent = true)
        {

            if (addUserAgent)
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.0.0 Safari/537.36");

            using (var response = await _httpClient.GetAsync(_downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                await DownloadFileFromHttpResponseMessage(response);
        }

        private async Task DownloadFileFromHttpResponseMessage(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength;

            using (var contentStream = await response.Content.ReadAsStreamAsync())
                await ProcessContentStream(totalBytes, contentStream);
        }

        private async Task ProcessContentStream(long? totalDownloadSize, Stream contentStream)
        {
            var totalBytesRead = 0L;
            var readCount = 0L;
            var buffer = new byte[8192];
            var isMoreToRead = true;

            using (var fileStream = new FileStream(_destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
            {
                do
                {
                    var bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        isMoreToRead = false;
                        TriggerProgressChanged(totalDownloadSize, totalBytesRead);
                        continue;
                    }

                    await fileStream.WriteAsync(buffer, 0, bytesRead);

                    totalBytesRead += bytesRead;
                    readCount += 1;

                    if (readCount % 100 == 0)
                        TriggerProgressChanged(totalDownloadSize, totalBytesRead);
                }
                while (isMoreToRead);
            }
        }

        private void TriggerProgressChanged(long? totalDownloadSize, long totalBytesRead)
        {
            if (ProgressChanged == null)
                return;

            double? progressPercentage = null;
            if (totalDownloadSize.HasValue)
                progressPercentage = Math.Round((double)totalBytesRead / totalDownloadSize.Value * 100, 2);

            ProgressChanged(totalDownloadSize, totalBytesRead, progressPercentage);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
