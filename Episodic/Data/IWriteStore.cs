using System.Threading.Tasks;
using System;
using System.Text.Json;
using System.Linq;
using System.Threading;

namespace Episodic
{
    public interface IWriteStore<T> where T: IStoreObject
    {
        Task<StoreUpdateResponse> Delete(Guid id);
        Task<StoreUpdateResponse> Update(T item);
    }

    public class WriteJsonStore<T> : IWriteStore<T> where T : IStoreObject
    {
        private readonly JsonStoreOption options;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private readonly SemaphoreSlim locker = new SemaphoreSlim(1);
        public WriteJsonStore(JsonStoreOption options)
        {
            this.options = options;
            jsonSerializerOptions = StoreHelper.JsonSerializerOptions();
        }

        public async Task<StoreUpdateResponse> Delete(Guid id)
        {
            await locker.WaitAsync();
            try
            {
                var path = StoreHelper.GetStorePath<T>(options.StoreBasePath);
                var result = await StoreHelper.Get<T>(path, jsonSerializerOptions);
                var updated = result with
                {
                    Items = result.Items.Where(w => w.Id != id).ToArray()
                };
                await StoreHelper.Write(path, updated, jsonSerializerOptions);
                return new StoreUpdateResponse(true);
            }
            finally
            {
                locker.Release();
            }

        }

        
        public async Task<StoreUpdateResponse> Update(T item)
        {
            await locker.WaitAsync();
            try
            {
                var path = StoreHelper.GetStorePath<T>(options.StoreBasePath);
                var result = await StoreHelper.Get<T>(path, jsonSerializerOptions);
                var updated = result with
                {
                    Items = result.Items.Where(w => w.Id != item.Id).Concat(new[] { item }).ToArray()
                };
                await StoreHelper.Write(path, updated, jsonSerializerOptions);
                return new StoreUpdateResponse(true);
            }
            finally
            {
                locker.Release();
            }
        }
    }



    public interface IStoreObject
    {
        Guid Id { get; }
    }
    public record StoreUpdateResponse(bool IsSuccessful) { }
}
