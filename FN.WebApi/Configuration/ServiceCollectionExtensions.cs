using FluentValidation;
using FluentValidation.Application.Validators;
using FN.Entities;
using FN.Application.Interfaces;
using FN.Application.Services;
using FN.Business.Abstractions;
using FN.Business.Services;
using FN.DataLayer.Abstractions;
using FN.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FN.WebApi.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUploadService, UploadService>();
            serviceCollection.AddScoped<IValidator<UploadModel>, UploadModelValidator>();
            return serviceCollection;
        }
        public static IServiceCollection AddBusinessServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUploadDataService, UploadDataService>();
            return serviceCollection;
        }
        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUploadRepository, UploadRepository>();
            return serviceCollection;
        }
    }
}
