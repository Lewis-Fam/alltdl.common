using System.Text.Json;

namespace alltdl.Utils;

/// <summary>The file helper.</summary>
public static class FileHelper
{
    /// <summary>Opens, reads, and parses a JSON file, and then closes the file.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path">   Fully qualified path of the JSON file.</param>
    /// <param name="options">JSON options.</param>
    /// <returns>A <typeparamref name="T"/> representation of the JSON file.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static T ReadFromJsonFile<T>(string path, JsonSerializerOptions? options = null) where T : class
    {
        return JsonHelper.ReadFromJsonFile<T>(path, options ?? JsonHelper.SerializerOptions()) ?? throw new InvalidOperationException($"Unable to read JSON file {path}");
    }

    /// <inheritdoc cref="System.IO.File.Move(string, string)"/>
    public static void Rename(string source, string destination)
    {
        File.Move(source, destination);
    }

    /// <summary><summary>Write T to a JSON file.</summary></summary>
    /// <param name="data">   The data.</param>
    /// <param name="path">   The path.</param>
    /// <param name="options">The options.</param>
    public static void WriteToJsonFile<T>(T data, string path, JsonSerializerOptions? options = null) where T : class
    {
        JsonHelper.WriteToJsonFile<T>(data, path, options ?? JsonHelper.SerializerOptions());
    }
}