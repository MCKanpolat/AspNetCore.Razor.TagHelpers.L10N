using AspNetCore.Razor.TagHelpers.L10N;
using AspNetCore.Razor.TagHelpers.L10N.Abstraction;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddL10Core(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizationService, LocalizationService>();
            services.AddSingleton<ILocalizationServiceCultureAccessor, DefaultLocalizationServiceCultureAccessor>();
            return services;
        }

        public static IServiceCollection AddL10N<T>(this IServiceCollection services) where T : PersistenceProviderBase
        {
            services.AddL10Core();
            services.AddSingleton<PersistenceProviderBase, T>();
            return services;
        }
    }
}
