namespace Episodic
{
    public class Episode
    {
        public string Description { get; init; } = string.Empty;
        public MacGuffin? MacGuffin { get; init; }
        public Faction? Faction { get; init; }

    }
}
