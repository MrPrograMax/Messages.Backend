using Microsoft.EntityFrameworkCore;
using Messages.Application.Interfaces;
using Messages.Domain;
using Messages.Persistance.EntityTypeConfiguration;

namespace Messages.Persistance
{
    public class MessagesDbContext : DbContext, IMessageDbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MessagesDbContext(DbContextOptions<MessagesDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
