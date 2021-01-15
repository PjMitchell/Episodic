using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Episodic.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactionController : BaseComponentController<Faction>
    {
        public FactionController(IMediator mediator) : base(mediator)
        {
        }
    }
}
