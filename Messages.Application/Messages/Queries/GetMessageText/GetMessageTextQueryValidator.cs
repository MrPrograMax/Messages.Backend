using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Application.Messages.Queries.GetMessageText
{
    public class GetMessageTextQueryValidator : AbstractValidator<GetMessageTextQuery>
    {
        public GetMessageTextQueryValidator() 
        {
            RuleFor(createMessageCommand => createMessageCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createMessageCommand => createMessageCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
