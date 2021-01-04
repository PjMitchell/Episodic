using System;

namespace Episodic
{
    public record MacGuffin : IEpisodeComponent, IComponentSummary
    {
        public EpisodeComponentType Type => EpisodeComponentType.MacGuffin;
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }

    public static class MacGuffinExtensions
    {
        public static MacGuffin? MacGuffinOrDefault(this EpisodeComponentCollection adventureComponentCollection)
        {
            return adventureComponentCollection.GetComponent(EpisodeComponentType.MacGuffin) as MacGuffin;
        }
    }
}
