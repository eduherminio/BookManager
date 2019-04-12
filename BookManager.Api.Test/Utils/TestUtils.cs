using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Api.Test.Utils
{
    public static class TestUtils
    {
        public static TestServer CreateTestServer<TStartup>()
            where TStartup : class
        {
            return CreateTestServer<TStartup>(ConfigurationHelper.GetConfiguration());
        }

        public static TestServer CreateTestServer<TStartup>(IConfiguration configuration)
            where TStartup : class
        {
            return CreateTestServer<TStartup>(configuration, (_) => { });
        }

        public static TestServer CreateTestServer<TStartup>(IConfiguration configuration, Action<IServiceCollection> configureServices)
            where TStartup : class
        {
            var hostBuilder = new WebHostBuilder()
                .UseConfiguration(configuration)
                .ConfigureServices(configureServices)
                .UseStartup<TStartup>();

            return new TestServer(hostBuilder);
        }

        public static HttpClient GetHttpClient(TestServer server) => server.CreateClient();
    }
}
