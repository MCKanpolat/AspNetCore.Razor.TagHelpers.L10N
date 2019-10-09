using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.Abstraction
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

        public async ValueTask<ContentTranslation> GetContentTranslationAsync(string cultureInfo, string key, string defaultContent = null)
        {
            var contentTranslation = await persistenceProvider.FindOneAsync(cultureInfo, key);
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
    }
}
