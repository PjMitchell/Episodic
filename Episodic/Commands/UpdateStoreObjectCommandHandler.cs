using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Episodic
{
    public class UpdateStoreObjectCommandHandler<T> : IRequestHandler<UpdateCommand<T>, CommandResult> where T : IStoreObject
    {
        private readonly IWriteStore<T> store;

        public UpdateStoreObjectCommandHandler(IWriteStore<T> store)
        {
            this.store = store;
        }

        public async Task<CommandResult> Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
        {
            var result = await store.Update(request.Item);
            return new CommandResult(result.IsSuccessful);
        }
    }
}
