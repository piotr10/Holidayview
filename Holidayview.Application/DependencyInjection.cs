using System.Reflection;
using AutoMapper;
using DelegationsMVC.Application.Services;
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
            services.AddTransient<IUserService, UserService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}