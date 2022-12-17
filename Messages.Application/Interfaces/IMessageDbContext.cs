using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Messages.Domain;

namespace Messages.Application.Interfaces
{
    public interface IMessageDbContext
    {
        DbSet<Message> Messages { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
