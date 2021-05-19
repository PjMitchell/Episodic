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
    public class GetByIdComponentEndpointHandlerTests
    {
        private readonly Mock<IMediator> mediator;
        private readonly Mock<IGuidIdRouteParser> idParser;


        private readonly GetByIdComponentEndpointHandler<Faction> target;

        public GetByIdComponentEndpointHandlerTests()
        {
            mediator = new Mock<IMediator>();
            idParser = new Mock<IGuidIdRouteParser>();
            target = new GetByIdComponentEndpointHandler<Faction>(mediator.Object, idParser.Object);
        }

        [Fact]
        public async Task Get_Id_ReturnsOkIfFound()
        {
            var id = Guid.NewGuid();
            idParser.Setup(s => s.GetIdFromRoute())
                .Returns(id);
            var expected = new Faction { Id = id, Name = "Bad Guys" }; 
            mediator.Setup(s => s.Send(It.Is<GetComponentByIdQuery<Faction>>(i => i.Id == id), It.IsAny<CancellationToken>())).ReturnsAsync(Maybe<Faction>.Create(expected));
            var result = await target.HandleAsync(CancellationToken.None);
            Assert.Equal(expected, result);

        }

        [Fact]
        public async Task Get_Id_ReturnsNotFound_IfNotFound()
        {
            var id = Guid.NewGuid();
            idParser.Setup(s => s.GetIdFromRoute())
                .Returns(id);
            mediator.Setup(s => s.Send(It.Is<GetComponentByIdQuery<Faction>>(i => i.Id == id), It.IsAny<CancellationToken>())).ReturnsAsync(new Maybe<Faction>.None());
            var result = await Assert.ThrowsAsync<EndpointStatusCodeResponseException>(() => target.HandleAsync( CancellationToken.None));
            Assert.Equal(404, result.StatusCode);
        }
    }
}
