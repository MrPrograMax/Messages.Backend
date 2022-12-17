using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Messages.Application.Messages.Queries.GetMessageList;
using Messages.Persistance;
using Messages.Tests.Common;
using Shouldly;
using Xunit;



namespace Messages.Tests.Messages.Queries
{
    [Collection("QueryCollection")]
    public class GetMessageListQueryHandlerTests
    {
        private readonly MessagesDbContext Context;
        private readonly IMapper Mapper;

        public GetMessageListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMessageListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetMessageListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetMessageListQuery
                {
                    UserId = MessagesContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<MessageListVm>();
            result.Messages.Count.ShouldBe(2);
        }
    }
}
