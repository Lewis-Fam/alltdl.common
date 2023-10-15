using alltdl.Extensions;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace alltdl.Utils
{
#pragma warning disable RCS1591

    /// <summary>
    /// The json helper utility
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Gets the json serializer options.
        /// </summary>
        public static JsonSerializerOptions JsonSerializerOptions => Converter.SerializerOptions();

        /// <summary>Opens a CSV file and reads all lines. Then converts the csv file to json.</summary>
        /// <param name="path">  The csv file path.</param>
        /// <param name="format">Format the json string.</param>
        /// <returns>A json string.</returns>
        public static string ConvertCsvFileToJson(string path, bool format = false)
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (var i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (var j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return Serialize(listObjResult, format ? Converter.SerializerOptions(true) : Converter.SerializerOptions());
        }

        public static string ConvertCsvTextToJson(string text, bool format = false)
        {
            var csv = new List<string[]>();
            string[] seperatingTags =
            {
                Environment.NewLine
            };
            var lines = text.Split(seperatingTags, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (var i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (var j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return Serialize(listObjResult, format ? Converter.SerializerOptions(true) : Converter.SerializerOptions());
        }

        /// <summary>
        /// ToDo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T? Deserialize<T>(string json, JsonSerializerOptions? options = null) where T : class
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }

        /// <summary>
        /// ToDo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <returns></returns>
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

        public static string Serialize<T>(T data, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Serialize(data, options);
        }

        internal static class Converter
        {
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
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                        new DateOnlyConverter(),
                        new TimeOnlyConverter(),
                        IsoDateTimeOffsetConverter.Singleton
                    }
                };
            }

            private class DateOnlyConverter : JsonConverter<DateOnly>
            {
                private readonly string serializationFormat;
                public DateOnlyConverter() : this(null) { }

                public DateOnlyConverter(string? serializationFormat)
                {
                    this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
                }

                public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                {
                    var value = reader.GetString();
                    return DateOnly.Parse(value!);
                }

                public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
                    => writer.WriteStringValue(value.ToString(serializationFormat));
            }

            private class TimeOnlyConverter : JsonConverter<TimeOnly>
            {
                private readonly string serializationFormat;

                public TimeOnlyConverter() : this(null) { }

                public TimeOnlyConverter(string? serializationFormat)
                {
                    this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
                }

                public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                {
                    var value = reader.GetString();
                    return TimeOnly.Parse(value!);
                }

                public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
                    => writer.WriteStringValue(value.ToString(serializationFormat));
            }

            private class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
            {
                public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

                private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

                private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
                private string? _dateTimeFormat;
                private CultureInfo? _culture;

                public DateTimeStyles DateTimeStyles
                {
                    get => _dateTimeStyles;
                    set => _dateTimeStyles = value;
                }

                public string? DateTimeFormat
                {
                    get => _dateTimeFormat ?? string.Empty;
                    set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
                }

                public CultureInfo Culture
                {
                    get => _culture ?? CultureInfo.CurrentCulture;
                    set => _culture = value;
                }

                public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
                {
                    string text;


                    if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                        || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                    {
                        value = value.ToUniversalTime();
                    }

                    text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

                    writer.WriteStringValue(text);
                }

                public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                {
                    string? dateText = reader.GetString();

                    if (string.IsNullOrEmpty(dateText) == false)
                    {
                        if (!string.IsNullOrEmpty(_dateTimeFormat))
                        {
                            return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                        }
                        else
                        {
                            return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                        }
                    }
                    else
                    {
                        return default(DateTimeOffset);
                    }
                }


                public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
            }
        }

        public static string ToJson<T>(this T data, bool writeIndented = false)
        {
            return Serialize(data, Converter.SerializerOptions(writeIndented));
        }

        public static async Task ToJsonAsync<T>(Stream stream, T data, bool writeIndented = false, CancellationToken token = default)
        {
            await JsonSerializer.SerializeAsync(stream, data, Converter.SerializerOptions(writeIndented), token).ConfigureAwait(false);
        }

        public static JsonDocument ToJsonDocument<T>(this T data, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.SerializeToDocument(data, typeof(T), options);
        }

        /// <summary><summary>Write T to a JSON file.</summary></summary>
        /// <param name="data">   The data.</param>
        /// <param name="path">   The path.</param>
        /// <param name="options">The options.</param>
        public static void WriteToJsonFile<T>(T data, string path, JsonSerializerOptions? options = null)
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
}