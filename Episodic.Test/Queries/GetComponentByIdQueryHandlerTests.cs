using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Queries
{
    public class GetComponentByIdQueryHandlerTests
    {
        private readonly Mock<IReadStore<TestComponent>> store;
        private readonly IRequestHandler<GetComponentByIdQuery<TestComponent>, Maybe<TestComponent>> target;
        public GetComponentByIdQueryHandlerTests()
        {
            store = new Mock<IReadStore<TestComponent>>();
            target = new GetComponentByIdQueryHandler<TestComponent>(store.Object);
        }

        [Fact]
        public async Task Handle_GetsItemFromStore()
        {
            var all = new TestComponent[]
            {
                new (Guid.NewGuid(), "one", "one description"),
                new (Guid.NewGuid(), "two", "two description"),

            };
            store.Setup(s => s.Get())
                .ReturnsAsync(all);
            var result = await target.Handle(new GetComponentByIdQuery<TestComponent>(all[0].Id), CancellationToken.None);
            var some = Assert.IsType<Maybe<TestComponent>.Some>(result);
            Assert.Equal(all[0], some.Value);
        }

        [Fact]
        public async Task Handle_ReturnsIfNotFound()
        {
            var all = new TestComponent[]
            {
                new (Guid.NewGuid(), "one", "one description"),
                new (Guid.NewGuid(), "two", "two description"),

            };
            store.Setup(s => s.Get())
                .ReturnsAsync(all);
            var result = await target.Handle(new GetComponentByIdQuery<TestComponent>(Guid.NewGuid()), CancellationToken.None);
            Assert.IsType<Maybe<TestComponent>.None>(result);
        }
    }
}
