using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Episodic
{
    public static class StoreHelper
    {
        public static string GetStorePath<T>(string basePath) => $"{basePath}/{typeof(T).Name}.json";

        public static JsonSerializerOptions JsonSerializerOptions()
        {
            var result = new JsonSerializerOptions
            {
                IgnoreReadOnlyFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            result.Converters.Add(new JsonStringEnumConverter());
            return result;
        }

        public static async Task<JsonStoreObject<T>> Get<T>(string path, JsonSerializerOptions jsonSerializerOptions)
        {
            if (!File.Exists(path))
            {
                await File.WriteAllBytesAsync(path, JsonSerializer.SerializeToUtf8Bytes(new JsonStoreObject<T>(Array.Empty<T>()), jsonSerializerOptions));
            }
            using (var file = File.OpenRead(path))
            {
                var result = await JsonSerializer.DeserializeAsync<JsonStoreObject<T>>(file, jsonSerializerOptions);
                return result ?? new JsonStoreObject<T>(Array.Empty<T>());
            }
        }

        public static Task Write<T>(string path, JsonStoreObject<T> storeObject, JsonSerializerOptions jsonSerializerOptions)
        {
            return File.WriteAllBytesAsync(path, JsonSerializer.SerializeToUtf8Bytes(storeObject, jsonSerializerOptions));
        }
    }
}
