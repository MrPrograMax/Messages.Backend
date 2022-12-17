using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Application.Messages.Commands.UpdateMessage
{
    public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
    {
        public UpdateMessageCommandValidator()
        {
            RuleFor(createMessageCommand => createMessageCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createMessageCommand => createMessageCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createMessageCommand => createMessageCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createMessageCommand => createMessageCommand.Text).NotEqual(String.Empty);
            RuleFor(createMessageCommand => createMessageCommand.DeleteAfterUpload).NotEmpty();


        }
    }
}
