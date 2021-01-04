using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Episodic
{
    public class GetComponentSummaryQueryHandler<TSource> : IRequestHandler<GetComponentSummaryQuery<TSource>, ComponentSummary[]> where TSource : IComponentSummary
    {
        private readonly IReadStore<TSource> store;

        public GetComponentSummaryQueryHandler(IReadStore<TSource> store)
        {
            this.store = store;
        }
        public async Task<ComponentSummary[]> Handle(GetComponentSummaryQuery<TSource> request, CancellationToken cancellationToken)
        {
            var items = await store.Get();
            return items.Select(s => new ComponentSummary(s)).ToArray();
        }
    }   
}
