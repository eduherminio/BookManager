using BookManager.Dao;
using BookManager.Dao.Impl;
using BookManager.Services;
using BookManager.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBookManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IBookManagerService, BookManagerService>();
            services.AddScoped<IBookDetailsRetrievalService, BookDetailsRetrievalService>();
            services.AddHttpClient<IBookDetailsRetrievalService, BookDetailsRetrievalService>();
            services.AddScoped<IBookDao, BookDaoEfImpl>();
        }
    }
}
