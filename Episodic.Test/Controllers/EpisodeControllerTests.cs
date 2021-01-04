using Episodic.Web.Controllers;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Controllers
{
    public class EpisodeControllerTests
    {
        private readonly Mock<IMediator> mediator;
        private readonly EpisodeController target;

        public EpisodeControllerTests()
        {
            mediator = new Mock<IMediator>();
            target = new EpisodeController(mediator.Object);
        }

        [Fact]
        public async Task Get_Works()
        {
            var episode = new Episode { Description = "test" };
            mediator.Setup(s => s.Send(It.IsAny<RandomEpisodeQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(episode);
            var result = await target.Get(CancellationToken.None);
            Assert.Equal(episode, result);
        }

    }
}
