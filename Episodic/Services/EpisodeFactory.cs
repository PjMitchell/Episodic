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
            var macGuffin = episodeComponents.GetComponent(EpisodeComponentType.MacGuffin) as MacGuffin;
            return new Episode 
            { 
                Description = episodeStringTemplateParser.ParseTemplate(template.DescriptionTemplate, episodeComponents), 
                MacGuffin = macGuffin 
            };
        }
    }
}
