using BookManager.Api.Constants;
using BookManager.Api.Logs;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BookManager.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogsExtensions.GetLogger();
            try
            {
                logger.Debug("Starting BookManager.Api");
                IConfiguration configuration = ConfigurationHelper.GetConfiguration();

                Task publicApi = BuildWebHost(args, configuration, AppSettingsKeys.UrlConfigurationKey)
                    .RunAsync();

                Task.WaitAll(publicApi);
            }
            catch (Exception e)
            {
                logger.Error(e, $"Stopped program because of exception: {e.Message}");
                throw;
            }
        }

        public static IWebHost BuildWebHost(string[] args, IConfiguration configuration, string urlKey)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseConfiguration(configuration)
                .UseStartup<Startup>()
                .UseUrls(configuration[urlKey])
                .UseCustomNlog()
                .Build();
        }
    }
}