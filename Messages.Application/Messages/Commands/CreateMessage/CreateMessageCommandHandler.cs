using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Messages.Application.Interfaces;
using Messages.Domain;

namespace Messages.Application.Messages.Commands.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Guid>
    {
        private readonly IMessageDbContext _dbContext;
        public CreateMessageCommandHandler(IMessageDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Text = request.Text,
                DeleteAfterUpload = request.DeleteAfterUpload,
                CreationDate = DateTime.Now,
                EditTime = null
            };
            message.UploadUrl = $"https://localhost:44356/api/1/Message/{message.Id}";

            await _dbContext.Messages.AddAsync(message, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return message.Id;
        }
    }
}
