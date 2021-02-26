using Microsoft.Extensions.DependencyInjection;
using Sample.CQRS.Domain.Interfaces.Repositories;
using Sample.CQRS.Infra.Oracle.Repositories;

namespace Sample.CQRS.Infra.Oracle
{
    public static class ModuleRegister
    {
        public static IServiceCollection AddOracleRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}