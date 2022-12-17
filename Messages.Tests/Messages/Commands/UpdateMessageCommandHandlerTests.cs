using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Messages.Application.Common.Exceptions;
using Messages.Application.Messages.Commands.UpdateMessage;
using Messages.Tests.Common;
using Xunit;

namespace Messages.Tests.Messages.Commands
{
    public class UpdateMessageCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateMessageCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateMessageCommandHandler(Context);
            var updatedTitle = "new title";

            // Act
            await handler.Handle(new UpdateMessageCommand
            {
                Id = MessagesContextFactory.MessageIdForUpdate,
                UserId = MessagesContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Messages.SingleOrDefaultAsync(m =>
                m.Id == MessagesContextFactory.MessageIdForUpdate &&
                m.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateMessageCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateMessageCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateMessageCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = MessagesContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateMessageCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateMessageCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateMessageCommand
                    {
                        Id = MessagesContextFactory.MessageIdForUpdate,
                        UserId = MessagesContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
