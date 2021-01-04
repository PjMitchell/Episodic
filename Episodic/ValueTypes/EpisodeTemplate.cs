using System;

namespace Episodic
{
    public record EpisodeTemplate: IComponentSummary
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string DescriptionTemplate { get; init; } = string.Empty;
        public EpisodeComponentType[] RequiredComponents { get; init; } = Array.Empty<EpisodeComponentType>();
    }
}
