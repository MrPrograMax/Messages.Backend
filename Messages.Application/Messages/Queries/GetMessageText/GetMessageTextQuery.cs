using MediatR;
using System;

namespace Messages.Application.Messages.Queries.GetMessageText
{
    public class GetMessageTextQuery : IRequest<MessageTextVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
