using System.Threading.Tasks;

namespace Episodic
{
    public class MacGuffinProvider : IEpisodeComponentProvider
    {
        public EpisodeComponentType Type => EpisodeComponentType.MacGuffin;

        private readonly IReadStore<MacGuffin> store;
        private readonly IRandomPicker randomPicker;

        public MacGuffinProvider(IReadStore<MacGuffin> store, IRandomPicker randomPicker)
        {
            this.store = store;
            this.randomPicker = randomPicker;
        }

        public async Task<IEpisodeComponent> GetComponent()
        {
            var available = await store.Get();
            if (available.Length == 0)
                return new MacGuffin { Name = "Nice cup of tea", Description = "Mmm perhaps we could have some MacGuffins to select from" };
            return randomPicker.Pick(available);
        }
    }    
}
