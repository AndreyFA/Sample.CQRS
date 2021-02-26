using Microsoft.Extensions.DependencyInjection;
using Sample.CQRS.Infra.Cache.Interfaces.Repositories;
using Sample.CQRS.Infra.Cache.Repositories;

namespace Sample.CQRS.Infra.Cache
{
    public static class ModuleRegister
    {
        public static IServiceCollection AddCacheRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerCacheRepository, CustomerCacheRepository>();
            return services;
        }
    }
}