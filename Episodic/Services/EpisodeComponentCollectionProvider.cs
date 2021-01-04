using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Episodic
{
    public interface IEpisodeComponentCollectionProvider
    {
        Task<EpisodeComponentCollection> GetComponents(EpisodeTemplate template);
    }

    public interface IEpisodeComponentProvider
    {
        EpisodeComponentType Type { get; }
        Task<IEpisodeComponent> GetComponent();
    }

    public class EpisodeComponentCollectionProvider : IEpisodeComponentCollectionProvider
    {
        private readonly Dictionary<EpisodeComponentType,IEpisodeComponentProvider> episodeComponentProviders;

        public EpisodeComponentCollectionProvider(IEpisodeComponentProvider[] episodeComponentProviders)
        {
            this.episodeComponentProviders = episodeComponentProviders.ToDictionary(k=> k.Type);
        }

        public async Task<EpisodeComponentCollection> GetComponents(EpisodeTemplate template)
        {
            var results = new IEpisodeComponent[template.RequiredComponents.Length];
            for(var i = 0; i< results.Length; i++)
            {
                results[i] = await GetComponent(template.RequiredComponents[i], template);
            }
            return new EpisodeComponentCollection(results.Where(w => w is not EmptyEpisodeComponent));
        }

        private Task<IEpisodeComponent> GetComponent(EpisodeComponentType type, EpisodeTemplate template)
        {
            if (episodeComponentProviders.TryGetValue(type, out var provider))
                return provider.GetComponent();
            return Task.FromResult<IEpisodeComponent>(EmptyEpisodeComponent.Default);
        }
    }
}
