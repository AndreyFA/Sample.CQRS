using Microsoft.Extensions.DependencyInjection;
using Sample.CQRS.Domain.Common;
using Sample.CQRS.Domain.Interfaces.Common;
using Sample.CQRS.Domain.Interfaces.Services;
using Sample.CQRS.Domain.Services;

namespace Sample.CQRS.Domain
{
    public static class ModuleRegister
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifications, Notifications>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}