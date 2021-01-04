using MediatR;
using System;

namespace Episodic
{
    public abstract record Command: IRequest<CommandResult>
    {
    }
}
