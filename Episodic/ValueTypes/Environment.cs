using System;

namespace Episodic
{
    public record Environment : IEpisodeComponent, IComponentSummary
    {
        public EpisodeComponentType Type => EpisodeComponentType.Environment;
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }

    public static class EnvironmentExtensions
    {
        public static Environment? EnvironmentOrDefault(this EpisodeComponentCollection adventureComponentCollection)
        {
            return adventureComponentCollection.GetComponent(EpisodeComponentType.Environment) as Environment;
        }
    }
}
