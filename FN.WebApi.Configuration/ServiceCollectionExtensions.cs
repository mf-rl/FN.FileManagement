using FluentValidation;
using FluentValidation.Application.Validators;
using FN.Application.Contract.Models;
using FN.Application.Contract.Services;
using FN.Application.Services;
using FN.Business.Contract.Abstractions;
using FN.Business.Services;
using FN.DataLayer.Contract.Abstractions;
using FN.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
