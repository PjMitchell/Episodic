using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Easy.Endpoints;

namespace Episodic.Web.Controllers
{
    [EpisodeComponents]
    [Delete("api/[type]/{id:guid}")]
    public class DeleteComponentEndpointHandler<T> : IJsonResponseEndpointHandler<CommandResult> where T : IComponentSummary
    {

        private readonly IMediator mediator;
        private readonly IGuidIdRouteParser idRouteParser;

        public DeleteComponentEndpointHandler(IMediator mediator, IGuidIdRouteParser idRouteParser)
        {
            this.mediator = mediator;
            this.idRouteParser = idRouteParser;
        }

        public Task<CommandResult> HandleAsync(CancellationToken cancellationToken)
        {
            var id = idRouteParser.GetIdFromRoute();
            return mediator.Send(new DeleteCommand<T>(id), cancellationToken);
        }
    }
}
