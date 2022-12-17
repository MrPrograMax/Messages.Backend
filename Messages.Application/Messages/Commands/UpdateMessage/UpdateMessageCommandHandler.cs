using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Messages.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Messages.Application.Common.Exceptions;
using Messages.Domain;

namespace Messages.Application.Messages.Commands.UpdateMessage
{
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand>
    {
        private readonly IMessageDbContext _dbContext;
        public UpdateMessageCommandHandler(IMessageDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Messages.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Message), request.Id);
            }

            entity.Title = request.Title;
            entity.Text = request.Text;
            entity.DeleteAfterUpload = request.DeleteAfterUpload;
            entity.EditTime = DateTime.Now;
            entity.DeleteAfterUpload = request.DeleteAfterUpload;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
