using MediatR;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Queries
{
    public class GetComponentSummaryQueryHandlerTests
    {
        private readonly Mock<IReadStore<TestComponent>> store;
        private readonly IRequestHandler<GetComponentSummaryQuery<TestComponent>, ComponentSummary[]> target;
        public GetComponentSummaryQueryHandlerTests()
        {
            store = new Mock<IReadStore<TestComponent>>();
            target = new GetComponentSummaryQueryHandler<TestComponent>(store.Object);
        }

        [Fact]
        public async Task Handle_GetsItemsFromStore()
        {
            var all = new TestComponent[]
            {
                new (Guid.NewGuid(), "one", "one description"),
                new (Guid.NewGuid(), "two", "two description"),

            };
            store.Setup(s => s.Get())
                .ReturnsAsync(all);
            var expected = all.Select(s => new ComponentSummary { Id = s.Id, Name = s.Name, Description = s.Description }).ToArray();
            var result = await target.Handle(new GetComponentSummaryQuery<TestComponent>(), CancellationToken.None);
            Assert.Equal(expected, result);
        }
    }
}
