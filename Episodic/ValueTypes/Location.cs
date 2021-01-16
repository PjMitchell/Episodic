using System;

namespace Episodic
{
    public record Location : IEpisodeComponent, IComponentSummary
    {
        public EpisodeComponentType Type => EpisodeComponentType.Location;
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }

    public static class LocationExtensions
    {
        public static Location? LocationOrDefault(this EpisodeComponentCollection adventureComponentCollection)
        {
            return adventureComponentCollection.GetComponent(EpisodeComponentType.Location) as Location;
        }
    }
}
