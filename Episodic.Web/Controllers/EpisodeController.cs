using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Episodic.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EpisodeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task<Episode> Get(CancellationToken cancellationToken)
        {
            return mediator.Send(new RandomEpisodeQuery(), cancellationToken);
        }
    }


}
