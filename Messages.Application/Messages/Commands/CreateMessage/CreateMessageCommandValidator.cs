using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Messages.Application.Messages.Commands.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator() 
        {
            RuleFor(createMessageCommand => createMessageCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createMessageCommand => createMessageCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createMessageCommand => createMessageCommand.Text).NotEqual(String.Empty);
            RuleFor(createMessageCommand => createMessageCommand.DeleteAfterUpload).NotEmpty();


        }
    }
}
