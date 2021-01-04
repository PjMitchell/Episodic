using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Episodic.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MacGuffinController : BaseComponentController<MacGuffin>
    {
        public MacGuffinController(IMediator mediator) : base(mediator)
        {
        }
    }


}
