using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Episodic
{
    public record RandomEpisodeQuery : IRequest<Episode>
    {

    }

    public class RandomEpisodeQueryHandler : IRequestHandler<RandomEpisodeQuery, Episode>
    {
        private readonly IEpisodeProvider episodeProvider;

        public RandomEpisodeQueryHandler(IEpisodeProvider episodeProvider)
        {
            this.episodeProvider = episodeProvider;
        }
        public Task<Episode> Handle(RandomEpisodeQuery request, CancellationToken cancellationToken)
        {
            return episodeProvider.Get();
        }
    }
}
