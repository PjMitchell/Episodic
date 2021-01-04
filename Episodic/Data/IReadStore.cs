using System.Threading.Tasks;
using System.Text.Json;

namespace Episodic
{
    public interface IReadStore<T>
    {
        Task<T[]> Get();
    }

    public record JsonStoreOption(string StoreBasePath)
    {

    }
    public class ReadJsonStore<T> : IReadStore<T>
    {
        private readonly JsonStoreOption options;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        public ReadJsonStore(JsonStoreOption options)
        {
            this.options = options;
            jsonSerializerOptions = StoreHelper.JsonSerializerOptions();
        }
        public async Task<T[]> Get()
        {
            var path = StoreHelper.GetStorePath<T>(options.StoreBasePath);
            var result = await StoreHelper.Get<T>(path, jsonSerializerOptions);
            return result.Items;
        }
    }

    
}
