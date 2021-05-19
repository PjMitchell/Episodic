using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Easy.Endpoints;

namespace Episodic.Web.Controllers
{
    [EpisodeComponents]
    [Post("api/[type]")]
    public class PostComponentEndpointHandler<T> : IJsonBodyAndResponseEndpointHandler<T, CommandResult> where T : IComponentSummary
    {

        private readonly IMediator mediator;

        public PostComponentEndpointHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<CommandResult> HandleAsync(T body, CancellationToken cancellationToken)
        {
            return mediator.Send(new UpdateCommand<T>(body), cancellationToken);
        }
    }
}
