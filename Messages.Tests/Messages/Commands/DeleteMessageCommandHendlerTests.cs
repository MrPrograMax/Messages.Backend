using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Messages.Application.Common.Exceptions;
using Messages.Application.Messages.Commands.DeleteMessage;
using Messages.Application.Messages.Commands.CreateMessage;
using Messages.Tests.Common;
using Xunit;



namespace Messages.Tests.Messages.Commands
{
    public class DeleteMessageCommandHendlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteMessageCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteMessageCommandHendlercs(Context);

            // Act
            await handler.Handle(new DeleteMessageCommand
            {
                Id = MessagesContextFactory.MessageIdForDelete,
                UserId = MessagesContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Messages.SingleOrDefault(m =>
                m.Id == MessagesContextFactory.MessageIdForDelete));
        }

        [Fact]
        public async Task DeleteMessageCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteMessageCommandHendlercs(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteMessageCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = MessagesContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteMessageCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteMessageCommandHendlercs(Context);
            var createHandler = new CreateMessageCommandHandler(Context);
            var messageId = await createHandler.Handle(
                new CreateMessageCommand
                {
                    Title = "MessageTitle",
                    UserId = MessagesContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteMessageCommand
                    {
                        Id = messageId,
                        UserId = MessagesContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
