using Messages.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messages.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<MessagesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IMessageDbContext>(provider =>
                provider.GetService<MessagesDbContext>());

            return services;
        }
    }
}
