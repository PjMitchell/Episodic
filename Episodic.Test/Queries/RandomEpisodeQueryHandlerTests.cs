using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Queries
{
    public class RandomEpisodeQueryHandlerTests
    {
        private readonly Mock<IEpisodeProvider> provider;
        private readonly IRequestHandler<RandomEpisodeQuery, Episode> target;
        public RandomEpisodeQueryHandlerTests()
        {
            provider = new Mock<IEpisodeProvider>();
            target = new RandomEpisodeQueryHandler(provider.Object);
        }

        [Fact]
        public async Task Handle_ReturnsFromService()
        {
            var episode = new Episode { Description = "Test" };
            provider.Setup(s => s.Get())
                .ReturnsAsync(episode);
            var result = await target.Handle(new RandomEpisodeQuery(), CancellationToken.None);
            Assert.Equal(episode, result);
        }
    }
}
