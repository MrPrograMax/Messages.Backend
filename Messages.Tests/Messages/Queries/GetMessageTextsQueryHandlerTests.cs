using AutoMapper;
using Messages.Application.Messages.Queries.GetMessageText;
using Messages.Persistance;
using Messages.Tests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Messages.Tests.Messages.Queries
{
    [Collection("QueryCollection")]
    public class GetMessageTextsQueryHandlerTests
    {
        private readonly MessagesDbContext Context;
        private readonly IMapper Mapper;

        public GetMessageTextsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMessageTextsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetMessageTextQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetMessageTextQuery
                {
                    UserId = MessagesContextFactory.UserBId,
                    Id = Guid.Parse("193F07BC-99BB-4EBF-AE47-BA305728DDA9")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<MessageTextVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
