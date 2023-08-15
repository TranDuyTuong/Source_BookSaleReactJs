using ConfigurationApplycations.BoSystem;
using ConfigurationApplycations.DataCommon;
using ConfigurationApplycations.KikanSystem;
using ConfigurationApplycations.User;
using ConfigurationInterfaces.BoSystem;
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

            // KikanSystem
            services.AddTransient<IHomeInitialization, HomeInitialization>();
            services.AddTransient<IimportDataKikanSystem, ImportDataKikanSystem>();

            // Bo System
            services.AddTransient<IAreaBO, AreaBO>();
            return services;
        }
    }
}
