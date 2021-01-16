using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Episodic.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : BaseComponentController<Location>
    {
        public LocationController(IMediator mediator) : base(mediator)
        {
        }
    }
}
