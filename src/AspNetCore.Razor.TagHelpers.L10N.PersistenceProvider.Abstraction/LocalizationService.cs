using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction
{
    public class LocalizationService : ILocalizationService
    {
        private readonly PersistenceProviderBase persistenceProvider;
        private readonly IOptions<L10NConfiguration> configuration;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public LocalizationService(PersistenceProviderBase persistenceProvider, IOptions<L10NConfiguration> configuration)
        {
            this.persistenceProvider = persistenceProvider ?? throw new ArgumentNullException(nameof(persistenceProvider));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<ContentTranslation> GetContentTranslationAsync(string cultureInfo, string key, string defaultContent = null)
        {
            var contentTranslation = await persistenceProvider.FindOneAsync(w => w.Key == key && w.CultureInfo == cultureInfo);
            if (contentTranslation == null && configuration.Value.AutoInsertWhenNotFound)
            {
                await semaphore.WaitAsync();
                try
                {
                    var newContent = new ContentTranslation() { Content = defaultContent, CultureInfo = cultureInfo, Key = key };
                    await persistenceProvider.AddAsync(newContent);
                    contentTranslation = newContent;
                }
                finally
                {
                    semaphore.Release();
                }
            }
            return contentTranslation;
        }

        public async Task<IEnumerable<ContentTranslation>> GetContentTranslationsAsync()
        {
            return await persistenceProvider.All();
        }
    }
}
