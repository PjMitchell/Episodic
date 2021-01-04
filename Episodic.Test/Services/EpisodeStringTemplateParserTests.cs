using Xunit;

namespace Episodic.Test
{
    public class EpisodeStringTemplateParserTests
    {
        private readonly IEpisodeStringTemplateParser target;

        public EpisodeStringTemplateParserTests()
        {
            target = new EpisodeStringTemplateParser();
        }

        [InlineData("Test", "Test")]
        [InlineData("Test: {{MacGuffin}}", "Test: One Ring")]
        [InlineData("Test: {{Bluerg}}", "Test: ERROR")]
        [Theory]
        public void Parse(string source, string expected)
        {
            var collection = new EpisodeComponentCollection(new IEpisodeComponent[] {
                new MacGuffin { Name = "One Ring"}
            });

            var result = target.ParseTemplate(source, collection);
            Assert.Equal(expected, result);
        }
    }
}
