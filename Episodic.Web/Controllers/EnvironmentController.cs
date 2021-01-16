using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Episodic.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvironmentController : BaseComponentController<Environment>
    {
        public EnvironmentController(IMediator mediator) : base(mediator)
        {
        }
    }
}
