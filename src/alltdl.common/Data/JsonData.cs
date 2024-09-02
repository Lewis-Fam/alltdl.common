using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using alltdl.Utils;

namespace alltdl.Data
{
    public static class JsonFile
    {
        public static async Task SaveAsync<T>(string path, T data, bool writeIndented = false, CancellationToken token = default)
        {
            await using var createStream = File.Create(path);
            await JsonHelper.SerializeAsync(createStream, data, writeIndented, token);
        }

        //public static async Task SaveAsync(string path, object data, bool writeIndented = false, CancellationToken token = default)
        //{
        //    await using var createStream = File.Create(path);
        //    await JsonHelper.SerializeAsync(createStream, data, writeIndented, token);
        //}

        public static void Save<T>(string path, T data, JsonSerializerOptions? options = null)
        {
            using var createStream = new StreamWriter(path);
            createStream.Write(JsonHelper.Serialize(data, options ?? JsonHelper.mJsonSerializerOptions.SerializerOptions()));
        }

        //public static void Save(string path, object data, JsonSerializerOptions? options = null)
        //{
        //    using var createStream = new StreamWriter(path);
        //    createStream.Write(JsonHelper.Serialize(data, options ?? JsonHelper.mJsonSerializerOptions.SerializerOptions()));
        //}

        public static async Task<T?> ReadAsync<T>(string path, JsonSerializerOptions? options = null) where T : class
        {
            await using var readStream = File.OpenRead(path);
            return await JsonHelper.DeserializeAsync<T>(readStream, options ?? JsonHelper.mJsonSerializerOptions.SerializerOptions());
        }

        public static T? Read<T>(string path, JsonSerializerOptions? options = null) where T : class
        {
            return JsonHelper.Deserialize<T>(ReadFile(path));
        }

        private static string ReadFile(string path)
        {
            using var readStream = new StreamReader(path);
            return readStream.ReadToEnd();
        }
    }
}
