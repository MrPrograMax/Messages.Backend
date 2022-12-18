using AutoMapper;
using MediatR;
using Messages.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Messages.Application.Common.Exceptions;
using Messages.Domain;

namespace Messages.Application.Messages.Queries.GetMessageText
{
    public class GetMessageTextQueryHandler : IRequestHandler<GetMessageTextQuery, MessageTextVm>
    {
        private readonly IMessageDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMessageTextQueryHandler(IMessageDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MessageTextVm> Handle(GetMessageTextQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Messages
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (entity == null) 
            {
                throw new NotFoundException(nameof(Message), request.Id);
            }

            return _mapper.Map<MessageTextVm>(entity);
        }
    }
}
