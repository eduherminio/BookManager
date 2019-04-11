using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System.IO;

namespace BookManager.Api.Logs
{
    public static class LogsExtensions
    {
        private const string NLogConfigFile = "nlog.config";
        private const string NLogDefaultConfigFile = "nlog.default.config";

        static LogsExtensions()
        {
            if (File.Exists(NLogConfigFile))
            {
                NLogBuilder.ConfigureNLog(NLogConfigFile);
            }
            else
            {
                NLogBuilder.ConfigureNLog(NLogDefaultConfigFile);
            }
        }

        public static IWebHostBuilder UseCustomNlog(this IWebHostBuilder builder)
        {
            return builder.ConfigureLogging((_, logging) =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            }).UseNLog();
        }

        public static NLog.Logger GetLogger()
        {
            return NLog.LogManager.GetCurrentClassLogger();
        }
    }
}
