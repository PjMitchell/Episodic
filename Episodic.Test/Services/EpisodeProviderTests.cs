using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test
{
    public class EpisodeProviderTests
    {
        private readonly Mock<IEpisodeTemplateProvider> templateProvider;
        private readonly Mock<IEpisodeFactory> episodeFactory;
        private readonly Mock<IEpisodeComponentCollectionProvider> episodeComponentProvider;
        private readonly EpisodeTemplate defaultTemplate;
        private readonly Episode defaultEpisode;
        private readonly EpisodeComponentCollection components;
        private readonly IEpisodeProvider target;

        public EpisodeProviderTests()
        {
            templateProvider = new Mock<IEpisodeTemplateProvider>();
            episodeFactory = new Mock<IEpisodeFactory>();
            episodeComponentProvider = new Mock<IEpisodeComponentCollectionProvider>();
            components = new EpisodeComponentCollection(new IEpisodeComponent[] { new MacGuffin { Name = "Orb" } });
            defaultTemplate = new EpisodeTemplate { DescriptionTemplate = "Wow what a fun adventure" };
            defaultEpisode = new Episode { Description = "A Fun Adventure" };
            templateProvider.Setup(s => s.GetRandom())
                .ReturnsAsync(() => defaultTemplate);
            episodeFactory.Setup(s => s.Build(defaultTemplate, components))
                .Returns(() => defaultEpisode);
            episodeComponentProvider.Setup(s => s.GetComponents(defaultTemplate))
                .ReturnsAsync(() => components);
            target = new EpisodeProvider(templateProvider.Object, episodeFactory.Object, episodeComponentProvider.Object);
        }


        [Fact]
        public async Task GetsEpisode()
        {
            var result = await target.Get();
            Assert.NotNull(result);
            Assert.Equal(defaultEpisode, result);
        }
    }
}
