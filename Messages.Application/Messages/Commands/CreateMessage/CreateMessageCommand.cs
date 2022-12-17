using System;
using MediatR;

namespace Messages.Application.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool DeleteAfterUpload { get; set; }

    }
}
