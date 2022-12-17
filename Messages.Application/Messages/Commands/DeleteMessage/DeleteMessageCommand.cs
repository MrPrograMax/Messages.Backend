using MediatR;
using System;

namespace Messages.Application.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

    }
}
