using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Messages.Application.Messages.Commands.CreateMessage;
using Messages.Tests.Common;
using Xunit;

namespace Messages.Tests.Messages.Commands
{
    public class CreateMessageCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateMessageCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateMessageCommandHandler(Context);
            var messageName = "message name";
            var messageTexts = "message texts";

            // Act
            var messageId = await handler.Handle(
                new CreateMessageCommand
                {
                    Title = messageName,
                    Text = messageTexts,
                    UserId = MessagesContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Messages.SingleOrDefaultAsync(m =>
                    m.Id == messageId && m.Title == messageName &&
                    m.Text == messageTexts));
        }
    }
}
