using System.Text.Json;
using System.Text.Json.Serialization;

namespace alltdl.Utils;

/// <summary>
/// The json helper utility
/// </summary>
public static class JsonHelper
{
    /// <summary>
    /// Gets the json serializer options.
    /// </summary>
    public static JsonSerializerOptions JsonSerializerOptions => SerializerOptions();

    /// <summary>Opens a CSV file and reads all lines. Then converts the csv file to json.</summary>
    /// <param name="path">  The csv file path.</param>
    /// <param name="format">Format the json string.</param>
    /// <returns>A json string.</returns>
    public static string ConvertCsvFileToJson(string path, bool format = false)
    {
        var csv = new List<string[]>();
        var lines = File.ReadAllLines(path);

        foreach (string line in lines)
            csv.Add(line.Split(','));

        var properties = lines[0].Split(',');

        var listObjResult = new List<Dictionary<string, string>>();

        for (int i = 1; i < lines.Length; i++)
        {
            var objResult = new Dictionary<string, string>();
            for (int j = 0; j < properties.Length; j++)
                objResult.Add(properties[j], csv[i][j]);

            listObjResult.Add(objResult);
        }

        //return JsonConvert.SerializeObject(listObjResult, format ? Formatting.Indented : Formatting.None);
        return Serialize(listObjResult, format ? SerializerOptions(true) : SerializerOptions());
    }

    /// <inheritdoc cref="JsonSerializer.Deserialize"/>
    public static T? Deserialize<T>(string json, JsonSerializerOptions? options = null) where T : class
    {
        return JsonSerializer.Deserialize<T>(json, options);
    }

    /// <inheritdoc cref="JsonSerializer.Deserialize"/>
    public static T? FromJson<T>(this string json, JsonSerializerOptions? options = null) where T : class
    {
        return Deserialize<T>(json, options);
    }

    /// <summary>Get an objects type description as a JSON string.</summary>
    /// <param name="obj">Object </param>
    /// <returns>Type description as a JSON string.</returns>
    public static string GetJsonTypeDescription(this object obj)
    {
        var description = obj.GetType().GetDescription();
        return description.ToJson();
    }

    /// <summary>Opens, reads, and parses a JSON file, and then closes the file.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path">   Fully qualified path of the JSON file.</param>
    /// <param name="options">JSON options.</param>
    /// <returns>A <typeparamref name="T"/> representation of the JSON file.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static T ReadFromJsonFile<T>(string path, JsonSerializerOptions? options = null) where T : class
    {
        return Deserialize<T>(File.ReadAllText(path), options) ?? throw new InvalidOperationException($"Unable to read JSON file {path}");
    }

    /// <inheritdoc cref="JsonSerializer.Serialize"/>
    public static string Serialize<T>(T data, JsonSerializerOptions? options = null) where T : class
    {
        return JsonSerializer.Serialize(data, options);
    }

    /// <inheritdoc cref="System.Text.Json.JsonSerializerOptions"/>
    public static JsonSerializerOptions SerializerOptions(bool writeIndented = false)
    {
        return new JsonSerializerOptions
        {
            WriteIndented = writeIndented,

            //IgnoreReadOnlyProperties = true,
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };
    }

    /// <inheritdoc cref="JsonSerializer.Serialize"/>
    public static string ToJson<T>(this T data, bool writeIndented = false) where T : class
    {
        return Serialize(data, SerializerOptions(writeIndented));
    }

    /// <summary><summary>Write T to a JSON file.</summary></summary>
    /// <param name="data">   The data.</param>
    /// <param name="path">   The path.</param>
    /// <param name="options">The options.</param>
    public static void WriteToJsonFile<T>(T data, string path, JsonSerializerOptions? options = null) where T : class
    {
        try
        {
            File.WriteAllText(path, Serialize(data, options));
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Unable to write JSON file {path}", e.InnerException);
        }
    }
}