using MediatR;
using Messages.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Messages.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQueryHandler : IRequestHandler<GetMessageListQuery, MessageListVm>
    {
        private readonly IMessageDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMessageListQueryHandler(IMessageDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MessageListVm> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            var messagesQuery = await _dbContext.Messages
                .Where(m => m.UserId == request.UserId)
                .ProjectTo<MessageLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MessageListVm { Messages = messagesQuery };
        }
    }
}
