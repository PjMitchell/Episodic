using Episodic.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Episodic.Test.Controllers
{
    public abstract class BaseComponentControllerTest<T> where T : IComponentSummary
    {
        private Mock<IMediator> mediator;

        private readonly BaseComponentController<T> target;

        protected BaseComponentControllerTest(Func<IMediator, BaseComponentController<T>> factory)
        {
            mediator = new Mock<IMediator>();
            target = factory(mediator.Object);
        }

        [Fact]
        public async Task Get_ReturnsAllSummaries()
        {
            var expected = new[] { new ComponentSummary { Id = Guid.NewGuid(), Name = "One", Description = "Test One" } };

            mediator.Setup(s => s.Send(It.IsAny<GetComponentSummaryQuery<T>>(), It.IsAny<CancellationToken>())).ReturnsAsync(expected);
            var result = await target.Get(CancellationToken.None);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Get_Id_ReturnsOkIfFound()
        {
            var id = Guid.NewGuid();
            var expected = Get(id);
            mediator.Setup(s => s.Send(It.Is<GetComponentByIdQuery<T>>(i => i.Id == id), It.IsAny<CancellationToken>())).ReturnsAsync(Maybe<T>.Create(expected));
            var result = await target.Get(id, CancellationToken.None);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var tResult = Assert.IsType<T>(okResult.Value);
            Assert.Equal(expected, tResult);

        }

        [Fact]
        public async Task Get_Id_ReturnsNotFound_IfNotFound()
        {
            var id = Guid.NewGuid();
            
            mediator.Setup(s => s.Send(It.Is<GetComponentByIdQuery<T>>(i => i.Id == id), It.IsAny<CancellationToken>())).ReturnsAsync(new Maybe<T>.None());
            var result = await target.Get(id, CancellationToken.None);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_Works()
        {
            var id = Guid.NewGuid();
            var input = Get(id);
            mediator.Setup(s => s.Send(It.Is<UpdateCommand<T>>(i => i.Item.Equals(input)), It.IsAny<CancellationToken>())).ReturnsAsync(new CommandResult(true));
            var result = await target.Post(input, CancellationToken.None);
            Assert.Equal(new CommandResult(true), result);

        }

        [Fact]
        public async Task Delete_Works()
        {
            var id = Guid.NewGuid();
            mediator.Setup(s => s.Send(It.Is<DeleteCommand<T>>(i => i.Id == id), It.IsAny<CancellationToken>())).ReturnsAsync(new CommandResult(true));
            var result = await target.Delete(id, CancellationToken.None);
            Assert.Equal(new CommandResult(true), result);

        }

        protected abstract T Get(Guid id);
    }
}
