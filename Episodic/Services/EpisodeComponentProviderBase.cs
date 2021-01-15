using System.Threading.Tasks;

namespace Episodic
{
    public abstract class EpisodeComponentProviderBase<T>: IEpisodeComponentProvider where T : IEpisodeComponent
    {
        public EpisodeComponentType Type => GetDefault().Type;

        private readonly IReadStore<T> store;
        private readonly IRandomPicker randomPicker;

        public EpisodeComponentProviderBase(IReadStore<T> store, IRandomPicker randomPicker)
        {
            this.store = store;
            this.randomPicker = randomPicker;
        }

        public async Task<IEpisodeComponent> GetComponent()
        {
            var available = await store.Get();
            if (available.Length == 0)
                return GetDefault();
            return randomPicker.Pick(available);
        }

        protected abstract T GetDefault();
    }
}
