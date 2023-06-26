using ConfigurationApplycations.User;
using ConfigurationInterfaces.User;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserConfiguration, UserConfiguration>();
            return services;
        }
    }
}
