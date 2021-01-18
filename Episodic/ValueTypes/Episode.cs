using System;

namespace Episodic
{
    public class Episode
    {
        public string Description { get; init; } = string.Empty;
        public MacGuffin? MacGuffin { get; init; }
        public Faction? Faction { get; init; }
        public Location? Location { get; init; }
        public Environment? Environment { get; init; }

        public EpisodeStage[] Stages { get; init; } = Array.Empty<EpisodeStage>();
    }
}
