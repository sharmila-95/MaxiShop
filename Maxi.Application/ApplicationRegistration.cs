using Maxi.Application.Common;
using Maxi.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;


namespace Maxi.Application
{
    public static class ApplicationRegistration
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services) 
        {
           services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            return services;
        }
    }
}
