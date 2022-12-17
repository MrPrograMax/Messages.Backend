using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Messages.Application.Common.Exceptions;
using Messages.Application.Interfaces;
using Messages.Domain;

namespace Messages.Application.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommandHendlercs : IRequestHandler<DeleteMessageCommand>
    {
        private readonly IMessageDbContext _dbContext;
        public DeleteMessageCommandHendlercs(IMessageDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Messages.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Message), request.Id);
            }

            _dbContext.Messages.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
