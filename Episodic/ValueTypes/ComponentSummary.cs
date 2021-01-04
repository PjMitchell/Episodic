using System;

namespace Episodic
{

    public interface IComponentSummary : IStoreObject
    {
        public string Name { get; }
        public string Description { get; }
    }

    public record ComponentSummary : IComponentSummary
    {
        public ComponentSummary()
        {

        }

        public ComponentSummary(IComponentSummary summary)
        {
            Id = summary.Id;
            Name = summary.Name;
            Description = summary.Description;
        }
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }

}
