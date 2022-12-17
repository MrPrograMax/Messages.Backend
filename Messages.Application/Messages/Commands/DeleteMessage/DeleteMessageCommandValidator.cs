using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Application.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
    {
        public DeleteMessageCommandValidator() 
        {
            RuleFor(createMessageCommand => createMessageCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createMessageCommand => createMessageCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
