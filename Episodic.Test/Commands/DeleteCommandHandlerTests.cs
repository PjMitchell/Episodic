using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Commands
{
    public class DeleteCommandHandlerTests
    {
        private readonly Mock<IWriteStore<TestComponent>> store;
        private readonly IRequestHandler<DeleteCommand<TestComponent>, CommandResult> target;
        public DeleteCommandHandlerTests()
        {
            store = new Mock<IWriteStore<TestComponent>>();
            target = new DeleteStoreObjectCommandHandler<TestComponent>(store.Object);
        }

        [Fact]
        public async Task Handle_SavesItemToStore()
        {
            var id = Guid.NewGuid();
            store.Setup(s => s.Delete(id))
                .ReturnsAsync(new StoreUpdateResponse(true));
            var result = await target.Handle(new DeleteCommand<TestComponent>(id), CancellationToken.None);
            Assert.True(result.IsSuccess);
            store.Verify(v => v.Delete(id), Times.Once);
        }
    }
}
