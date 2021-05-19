using Episodic.Web.Controllers;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Controllers
{
    public class PostEpisodeEndpointHandlerTests
    {
        private readonly Mock<IMediator> mediator;
        private readonly PostEpisodeEndpointHandler target;

        public PostEpisodeEndpointHandlerTests()
        {
            mediator = new Mock<IMediator>();
            target = new PostEpisodeEndpointHandler(mediator.Object);
        }

        [Fact]
        public async Task Get_Works()
        {
            var episode = new Episode { Description = "test" };
            mediator.Setup(s => s.Send(It.IsAny<RandomEpisodeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(episode);
            var result = await target.HandleAsync(CancellationToken.None);
            Assert.Equal(episode, result);
        }

    }
}
