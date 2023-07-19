using ConfigurationApplycations.DataCommon;
using ConfigurationApplycations.KikanSystem;
using ConfigurationApplycations.User;
using ConfigurationInterfaces.DataCommon;
using ConfigurationInterfaces.KikanSystem;
using ConfigurationInterfaces.User;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserConfiguration, UserConfiguration>();
            services.AddTransient<IContactCommon, ContactCommon>();
            services.AddTransient<IHomeInitialization, HomeInitialization>();
            return services;
        }
    }
}
