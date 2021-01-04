using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Episodic.Web.Controllers
{
    public abstract class BaseComponentController<T> : ControllerBase where T : IComponentSummary
    {
        private readonly IMediator mediator;

        public BaseComponentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<ComponentSummary[]> Get(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetComponentSummaryQuery<T>(), cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetComponentByIdQuery<T>(id), cancellationToken);
            if (result is Maybe<T>.Some some)
                return Ok(some.Value);
            return NotFound();
        }

        [HttpPost]
        public Task<CommandResult> Post(T value, CancellationToken cancellationToken)
        {
            return mediator.Send(new UpdateCommand<T>(value), cancellationToken);
        }

        [HttpDelete("{id}")]
        public Task<CommandResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeleteCommand<T>(id), cancellationToken);
        }
    }


}
