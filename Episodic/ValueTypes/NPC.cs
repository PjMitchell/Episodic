namespace Episodic
{
    public record NPC
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;

        public static readonly NPC Empty = new NPC(); 
    }
}
