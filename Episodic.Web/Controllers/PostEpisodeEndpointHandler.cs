using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Easy.Endpoints;

namespace Episodic.Web.Controllers
{
    public class PostEpisodeEndpointHandler : IJsonResponseEndpointHandler<Episode>
    {
        private readonly IMediator mediator;

        public PostEpisodeEndpointHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<Episode> HandleAsync(CancellationToken cancellationToken)
        {
            return mediator.Send(new RandomEpisodeQuery(), cancellationToken);
        }
    }
}
