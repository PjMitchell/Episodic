using Episodic.Web.Controllers;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Easy.Endpoints;

namespace Episodic.Test.Controllers
{
    public class DeleteComponentEndpointHandlerTests
    {
        private readonly Mock<IMediator> mediator;
        private readonly Mock<IGuidIdRouteParser> idParser;


        private readonly DeleteComponentEndpointHandler<Faction> target;

        public DeleteComponentEndpointHandlerTests()
        {
            mediator = new Mock<IMediator>();
            idParser = new Mock<IGuidIdRouteParser>();
            target = new DeleteComponentEndpointHandler<Faction>(mediator.Object, idParser.Object);
        }

        [Fact]
        public async Task Delete_Works()
        {
            var id = Guid.NewGuid();
            idParser.Setup(s => s.GetIdFromRoute())
                .Returns(id);
            mediator.Setup(s => s.Send(It.Is<DeleteCommand<Faction>>(i => i.Id == id), It.IsAny<CancellationToken>())).ReturnsAsync(new CommandResult(true));
            var result = await target.HandleAsync(CancellationToken.None);
            Assert.Equal(new CommandResult(true), result);

        }
    }
}
