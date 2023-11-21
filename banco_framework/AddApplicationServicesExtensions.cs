using Application.Services;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace bancoFramework
{
    public static class AddApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicatonServices(this IServiceCollection services)
        {
            services.AddTransient<IClienteServices, ClienteServices>();
            services.AddTransient<IMenuServices, MenuServices>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
