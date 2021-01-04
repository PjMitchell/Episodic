using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Episodic.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodeTemplateController : BaseComponentController<EpisodeTemplate>
    {
        public EpisodeTemplateController(IMediator mediator) : base(mediator)
        {
        }
    }


}
