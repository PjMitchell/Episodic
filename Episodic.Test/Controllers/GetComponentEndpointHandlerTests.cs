using Episodic.Web.Controllers;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Controllers
{
    public class GetComponentEndpointHandlerTests
    {
        private readonly Mock<IMediator> mediator;


        private readonly GetComponentEndpointHandler<Faction> target;

        public GetComponentEndpointHandlerTests()
        {
            mediator = new Mock<IMediator>();
            target = new GetComponentEndpointHandler<Faction>(mediator.Object);
        }


        [Fact]
        public async Task Get_ReturnsAllSummaries()
        {
            var expected = new[] { new ComponentSummary { Id = Guid.NewGuid(), Name = "One", Description = "Test One" } };

            mediator.Setup(s => s.Send(It.IsAny<GetComponentSummaryQuery<Faction>>(), It.IsAny<CancellationToken>())).ReturnsAsync(expected);
            var result = await target.HandleAsync(CancellationToken.None);
            Assert.Equal(expected, result);
        }
    }
}
