using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test
{
    public class EpisodeTemplateProviderTests
    {
        private readonly Mock<IReadStore<EpisodeTemplate>> store;
        private readonly IEpisodeTemplateProvider target;

        public EpisodeTemplateProviderTests()
        {
            store = new Mock<IReadStore<EpisodeTemplate>>();
            target = new EpisodeTemplateProvider(store.Object, new AlwaysPicksFirst());
        }

        [Fact]
        public async Task GetRandom_GetsRandomFromAllOptions()
        {
            var allOptions = new[]
            {
                new EpisodeTemplate{ Name = "One"},
                new EpisodeTemplate{ Name = "Two"}
            };
            store.Setup(s => s.Get()).ReturnsAsync(allOptions);
            var result = await target.GetRandom();
            Assert.Equal(allOptions[0], result);
        }

    }
}
