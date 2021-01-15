using System;

namespace Episodic
{
    public record Faction : IEpisodeComponent, IComponentSummary
    {

        public EpisodeComponentType Type => EpisodeComponentType.Faction;
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public NPC Boss { get; init; } = NPC.Empty;
    }

    public static class FactionExtensions
    {
        public static Faction? FactionOrDefault(this EpisodeComponentCollection adventureComponentCollection)
        {
            return adventureComponentCollection.GetComponent(EpisodeComponentType.Faction) as Faction;
        }
    }
}
