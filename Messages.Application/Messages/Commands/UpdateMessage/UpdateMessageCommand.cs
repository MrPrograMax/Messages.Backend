using System;
using MediatR;

namespace Messages.Application.Messages.Commands.UpdateMessage
{
    public class UpdateMessageCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool DeleteAfterUpload { get; set; }

    }
}

