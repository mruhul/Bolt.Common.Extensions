using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bolt.Common.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions().ApplyBasicOptions();
        private static readonly JsonSerializerOptions optionsIndented;

        static JsonExtensions()
        {
            optionsIndented = new JsonSerializerOptions().ApplyBasicOptions();
            optionsIndented.WriteIndented = true;
        }

        /// <summary>
        /// Basic options set for json serializer options
        /// - Add string to enum converter
        /// - PropertyNamingPolicy to CamelCase
        /// - PropertyNameCaseInsensitive is false
        /// - Ignore null values
        /// - WriteIndented false
        /// - With JsonStringEnumConverter
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static JsonSerializerOptions ApplyBasicOptions(this JsonSerializerOptions source)
        {
            source.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            source.PropertyNameCaseInsensitive = false;
            source.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            source.WriteIndented = false;
            source.Converters.Add(new JsonStringEnumConverter());
            return source;
        }

        /// <summary>
        /// Serialize an object using ideal options <see cref="ApplyBasicOptions"/> and process is null safe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T source) where T : class
            => source == null ? null : JsonSerializer.Serialize(source, options);

        /// <summary>
        /// Serialize an object using ideal options <see cref="ApplyBasicOptions"/> except its indented and process is null safe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToPrettyJson<T>(this T source)
            => source == null 
                ? null 
                : JsonSerializer.Serialize(source, optionsIndented);

        /// <summary>
        /// Deserialize a serialized string to supplied T using Ideal otpions <see cref="ApplyBasicOptions"/> and process is null safe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string source)
            => string.IsNullOrWhiteSpace(source) 
                ? default 
                : JsonSerializer.Deserialize<T>(source, options);

        
    }
}
