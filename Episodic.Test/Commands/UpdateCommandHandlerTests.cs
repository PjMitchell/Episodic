using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Commands
{
    public class UpdateCommandHandlerTests
    {
        private readonly Mock<IWriteStore<TestComponent>> store;
        private readonly IRequestHandler<UpdateCommand<TestComponent>, CommandResult> target;
        public UpdateCommandHandlerTests()
        {
            store = new Mock<IWriteStore<TestComponent>>();
            target = new UpdateStoreObjectCommandHandler<TestComponent>(store.Object);
        }

        [Fact]
        public async Task Handle_SavesItemToStore()
        {
            var item = new TestComponent(Guid.NewGuid(), "one", "one description");
            store.Setup(s => s.Update(item))
                .ReturnsAsync(new StoreUpdateResponse(true));
            var result = await target.Handle(new UpdateCommand<TestComponent>(item), CancellationToken.None);
            Assert.True(result.IsSuccess);
            store.Verify(v => v.Update(item), Times.Once);
        }
    }
}
