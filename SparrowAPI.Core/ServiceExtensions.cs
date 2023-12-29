using Microsoft.Extensions.DependencyInjection;
using SparrowAPI.Core.AutoMapper.Categories;
using SparrowAPI.Core.AutoMapper.User;
using SparrowAPI.Core.Interfaces;
using SparrowAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<EmailService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IJwtService, JwtService>();
        }

        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile));
            services.AddAutoMapper(typeof(AutoMapperCategoryProfile));
        }
    }
}
