namespace Episodic
{
    public interface IEpisodeFactory
    {
        Episode Build(EpisodeTemplate template, EpisodeComponentCollection episodeComponents);
    }
    public class EpisodeFactory : IEpisodeFactory
    {
        private readonly IEpisodeStringTemplateParser episodeStringTemplateParser;

        public EpisodeFactory(IEpisodeStringTemplateParser episodeStringTemplateParser)
        {
            this.episodeStringTemplateParser = episodeStringTemplateParser;
        }

        public Episode Build(EpisodeTemplate template, EpisodeComponentCollection episodeComponents)
        {
            return new Episode 
            { 
                Description = episodeStringTemplateParser.ParseTemplate(template.DescriptionTemplate, episodeComponents), 
                MacGuffin = episodeComponents.MacGuffinOrDefault(),
                Faction = episodeComponents.FactionOrDefault(),
                Location = episodeComponents.LocationOrDefault(),
                Environment = episodeComponents.EnvironmentOrDefault()
            };
        }
    }
}
