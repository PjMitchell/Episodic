using System;

namespace Episodic.Test
{
    public record TestComponent(Guid Id, string Name, string Description) : IComponentSummary { }
}
