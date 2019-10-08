using AspNetCore.Razor.TagHelpers.L10N;
using AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddL10Core(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizationService, LocalizationService>();
            return services;
        }

        public static IServiceCollection AddL10NWithDefaults(this IServiceCollection services)
        {
            services.AddL10Core();
            services.AddSingleton<ILocalizationServiceCultureAccessor, DefaultLocalizationServiceCultureAccessor>();

            return services;
        }
    }
}
