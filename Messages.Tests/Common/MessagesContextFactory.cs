using Messages.Domain;
using Messages.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Tests.Common
{
    public class MessagesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid MessageIdForDelete = Guid.NewGuid();
        public static Guid MessageIdForUpdate = Guid.NewGuid();

        public static MessagesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<MessagesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new MessagesDbContext(options);
            context.Database.EnsureCreated();
            context.Messages.AddRange(
                new Message
                {
                    Id = Guid.Parse("29C69F39-80B8-4B39-AE7C-499B177D02A4"),
                    UserId = UserAId,
                    Title = "Title1",
                    Text = "Text1",
                    CreationDate = DateTime.Today,
                    EditTime = null,
                },
                new Message
                {
                    Id = Guid.Parse("193F07BC-99BB-4EBF-AE47-BA305728DDA9"),
                    UserId = UserBId,
                    Title = "Title2",
                    Text = "Text2",
                    CreationDate = DateTime.Today,
                    EditTime = null,
                },
                new Message
                {
                    Id = MessageIdForDelete,
                    UserId = UserAId,
                    Title = "Title3",
                    Text = "Text3",
                    CreationDate = DateTime.Today,
                    EditTime = null,
                },
                new Message
                {
                    Id = MessageIdForUpdate,
                    UserId = UserBId,
                    Title = "Title4",
                    Text = "Text4",
                    CreationDate = DateTime.Today,
                    EditTime = null,
                }
             );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(MessagesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }


}
