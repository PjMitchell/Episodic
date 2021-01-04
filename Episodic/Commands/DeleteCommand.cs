using System;

namespace Episodic
{
    public record DeleteCommand<T>(Guid Id) : Command where T : IStoreObject
    {         
    }
}
