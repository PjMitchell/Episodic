using System.Linq;

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
                Environment = episodeComponents.EnvironmentOrDefault(),
                Stages = template.Stages.Select(s => BuildStage(s, episodeComponents)).ToArray()
            };
        }

        private EpisodeStage BuildStage(EpisodeStageTemplate template, EpisodeComponentCollection episodeComponents)
        {
            return new EpisodeStage
            {
                Name = template.Name,
                Description = episodeStringTemplateParser.ParseTemplate(template.DescriptionTemplate, episodeComponents)
            };
        }
    }
}
