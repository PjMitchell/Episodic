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
        [InlineData("Test: {{Faction}}", "Test: Legion of Doom")]
        [InlineData("Test: {{Faction.Boss}}", "Test: Big Boss")]

        [Theory]
        public void Parse(string source, string expected)
        {
            var collection = new EpisodeComponentCollection(new IEpisodeComponent[] {
                new MacGuffin { Name = "One Ring"},
                new Faction { Name = "Legion of Doom", Boss = new NPC{ Name = "Big Boss" } }
            });

            var result = target.ParseTemplate(source, collection);
            Assert.Equal(expected, result);
        }
    }
}
