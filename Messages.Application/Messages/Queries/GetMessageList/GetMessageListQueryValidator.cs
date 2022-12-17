using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQueryValidator : AbstractValidator<GetMessageListQuery>
    {
        public GetMessageListQueryValidator() 
        {
            RuleFor(createMessageCommand => createMessageCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
