using BookManager.Api.Constants;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookManager.Api
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(AppSettingsKeys.ConfigurationFile, optional: false, reloadOnChange: false)
                    .AddEnvironmentVariables()
                .Build();
        }
    }
}
