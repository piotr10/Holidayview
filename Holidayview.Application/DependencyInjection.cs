using System.Reflection;
using AutoMapper;
using Holidayview.Application.Interfaces;
using Holidayview.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Holidayview.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}