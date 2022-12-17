using System;
using MediatR;

namespace Messages.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQuery : IRequest<MessageListVm>
    {
        public Guid UserId { get; set; }

    }
}
