using Holidayview.Domain.Interfaces;
using Holidayview.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Holidayview.Infrastructure
{
    public static class DependencyInjection
    { public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}