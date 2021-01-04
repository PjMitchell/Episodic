using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Episodic
{
    public class GetComponentByIdQueryHandler<TResult> : IRequestHandler<GetComponentByIdQuery<TResult>, Maybe<TResult>> where TResult : IStoreObject
    {
        private readonly IReadStore<TResult> store;

        public GetComponentByIdQueryHandler(IReadStore<TResult> store)
        {
            this.store = store;
        }
        public async Task<Maybe<TResult>> Handle(GetComponentByIdQuery<TResult> request, CancellationToken cancellationToken)
        {
            var items = await store.Get();
            var result = items.FirstOrDefault(s => s.Id == request.Id);
            return Maybe<TResult>.Create(result);
        }
    }    
}
