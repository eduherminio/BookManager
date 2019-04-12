using BookManager.Api;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BookManager.Api.Test.Utils
{
    public class Fixture : IDisposable
    {
        public readonly TestServer Server;

        public Fixture()
        {
            IEnumerable<KeyValuePair<string, string>> initialData = new List<KeyValuePair<string, string>>()
            {
                KeyValuePair.Create("ConnectionString", "Server = localhost; Database = HomeBook_Library_Test; Trusted_Connection = True;")
            };

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(initialData);
            IConfiguration configuration = configurationBuilder.Build();
            Server = TestUtils.CreateTestServer<Startup>(configuration);
        }

        public HttpClient GetClient() => TestUtils.GetHttpClient(Server);

        public TService GetService<TService>()
        {
            return (TService)Server.Host.Services.GetRequiredService(typeof(TService));
        }

        public Uri CreateUri(string str) => new Uri(str, UriKind.Relative);

        protected virtual void Dispose(bool disposing)
        {
            GetService<BookManagerDbContext>().Database.EnsureDeleted();

            Server.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
