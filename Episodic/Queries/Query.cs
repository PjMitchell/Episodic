using MediatR;

namespace Episodic
{
    public abstract record Query<TResult> : IRequest<TResult>
    {
    }
}
