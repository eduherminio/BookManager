using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookManager.Orm.Provider
{
    public interface IDbContextProvider
    {
        void WireDbContext(IServiceCollection services, IConfiguration configuration, string connectionString);
    }

    public class DbContextProvider : IDbContextProvider
    {
        public virtual void WireDbContext(IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddDbContext<BookManagerDbContext>(GetDatabaseOptions(connectionString), ServiceLifetime.Scoped);
            services.AddScoped<IBookManagerContextContainer, BookManagerContextContainer<BookManagerDbContext>>();
        }

        private static Action<IServiceProvider, DbContextOptionsBuilder> GetDatabaseOptions(string connectionString)
        {
            return (_, builder) =>
            {
                builder.UseSqlServer(connectionString);
                builder.EnableSensitiveDataLogging();
            };
        }

        public void WireContextContainer(IServiceCollection services)
        {

        }
    }
}
