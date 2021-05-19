using Episodic.Web.Controllers;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Controllers
{
    public class PostComponentEndpointHandlerTests
    {
        private readonly Mock<IMediator> mediator;


        private readonly PostComponentEndpointHandler<Faction> target;

        public PostComponentEndpointHandlerTests()
        {
            mediator = new Mock<IMediator>();
            target = new PostComponentEndpointHandler<Faction>(mediator.Object);
        }


        [Fact]
        public async Task Post_Works()
        {
            var id = Guid.NewGuid();
            var input = new Faction { Id = id, Name = "Bad Guys" };
            mediator.Setup(s => s.Send(It.Is<UpdateCommand<Faction>>(i => i.Item.Equals(input)), It.IsAny<CancellationToken>())).ReturnsAsync(new CommandResult(true));
            var result = await target.HandleAsync(input, CancellationToken.None);
            Assert.Equal(new CommandResult(true), result);

        }
    }
}
