using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Easy.Endpoints;

namespace Episodic.Web.Controllers
{
    [EpisodeComponents]
    [Get("api/[type]")]
    public class GetComponentEndpointHandler<T> : IJsonResponseEndpointHandler<ComponentSummary[]> where T : IComponentSummary
    {

        private readonly IMediator mediator;

        public GetComponentEndpointHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<ComponentSummary[]> HandleAsync(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetComponentSummaryQuery<T>(), cancellationToken);
        }
    }
}
