using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Easy.Endpoints;

namespace Episodic.Web.Controllers
{
    [EpisodeComponents]
    [Get("api/[type]/{id:guid}")]
    public class GetByIdComponentEndpointHandler<T> : IJsonResponseEndpointHandler<T> where T : IComponentSummary
    {

        private readonly IMediator mediator;
        private readonly IGuidIdRouteParser idRouteParser;


        public GetByIdComponentEndpointHandler(IMediator mediator, IGuidIdRouteParser idRouteParser)
        {
            this.mediator = mediator;
            this.idRouteParser = idRouteParser;
        }

        public async Task<T> HandleAsync(CancellationToken cancellationToken)
        {
            var id = idRouteParser.GetIdFromRoute();
            var result = await mediator.Send(new GetComponentByIdQuery<T>(id), cancellationToken);
            if (result is Maybe<T>.Some some)
                return some.Value;
            throw new EndpointStatusCodeResponseException(404, "Not Found");
        }
    }
}
