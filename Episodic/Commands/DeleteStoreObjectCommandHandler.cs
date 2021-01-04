using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Episodic
{
    public class DeleteStoreObjectCommandHandler<T> : IRequestHandler<DeleteCommand<T>, CommandResult> where T : IStoreObject
    {
        private readonly IWriteStore<T> store;

        public DeleteStoreObjectCommandHandler(IWriteStore<T> store)
        {
            this.store = store;
        }

        public async Task<CommandResult> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            var result = await store.Delete(request.Id);
            return new CommandResult(result.IsSuccessful);
        }
    }
}
