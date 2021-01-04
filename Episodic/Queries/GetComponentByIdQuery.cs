using System;

namespace Episodic
{
    public record GetComponentByIdQuery<TResult>(Guid Id) : Query<Maybe<TResult>> where TResult : IStoreObject
    {

    }
}
