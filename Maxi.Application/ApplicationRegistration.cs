﻿using Maxi.Application.Common;
using Maxi.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;


namespace Maxi.Application
{
    public static class ApplicationRegistration
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services) 
        {
           services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
            
            return services;
        }
    }
}
