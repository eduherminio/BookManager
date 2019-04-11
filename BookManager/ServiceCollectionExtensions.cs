using BookManager.Services;
using BookManager.Services.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookManager
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBookManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IBookManagerService, BookManagerService>();
        }
    }
}
