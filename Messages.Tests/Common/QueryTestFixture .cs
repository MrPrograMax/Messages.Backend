using AutoMapper;
using Messages.Application.Common.Mappings;
using Messages.Application.Interfaces;
using Messages.Persistance;
using System;
using Xunit;

namespace Messages.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public MessagesDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = MessagesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IMessageDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            MessagesContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

