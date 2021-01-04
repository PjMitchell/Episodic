using System.Threading.Tasks;

namespace Episodic
{
    public interface IEpisodeTemplateProvider
    {
        Task<EpisodeTemplate> GetRandom();
    }

    public class EpisodeTemplateProvider : IEpisodeTemplateProvider
    {
        private readonly IReadStore<EpisodeTemplate> store;
        private readonly IRandomPicker randomPicker;

        public EpisodeTemplateProvider(IReadStore<EpisodeTemplate> store, IRandomPicker randomPicker)
        {
            this.store = store;
            this.randomPicker = randomPicker;
        }

        public async Task<EpisodeTemplate> GetRandom()
        {
            var available = await store.Get();
            if (available.Length == 0)
                return new EpisodeTemplate { DescriptionTemplate = "Let's have a nice cup of tea in front of the tele." };
            return randomPicker.Pick(available);
        }
    }


}
