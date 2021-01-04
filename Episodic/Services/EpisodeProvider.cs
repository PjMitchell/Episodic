using System.Threading.Tasks;

namespace Episodic
{
    public interface IEpisodeProvider
    {
        Task<Episode> Get();
    }

    public class EpisodeProvider : IEpisodeProvider
    {

        private readonly IEpisodeTemplateProvider templateProvider;
        private readonly IEpisodeComponentCollectionProvider componentProvider;
        private readonly IEpisodeFactory episodeFactory;

        public EpisodeProvider(IEpisodeTemplateProvider templateProvider, IEpisodeFactory episodeFactory, IEpisodeComponentCollectionProvider componentProvider)
        {
            this.templateProvider = templateProvider;
            this.episodeFactory = episodeFactory;
            this.componentProvider = componentProvider;
        }

        public async Task<Episode> Get()
        {
            var template = await templateProvider.GetRandom();
            var components = await componentProvider.GetComponents(template);
            return episodeFactory.Build(template, components);    
        }
    }
}
