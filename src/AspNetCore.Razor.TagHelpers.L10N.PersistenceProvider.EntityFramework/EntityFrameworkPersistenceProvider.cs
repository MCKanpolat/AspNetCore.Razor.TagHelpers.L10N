using AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.EntityFramework
{
    public class EntityFrameworkPersistenceProvider : PersistenceProviderBase
    {
        private readonly LocalizationDbContext localizationDbContext;

        public EntityFrameworkPersistenceProvider(LocalizationDbContext localizationDbContext)
        {
            this.localizationDbContext = localizationDbContext ?? throw new ArgumentNullException(nameof(localizationDbContext));
        }

        public override async ValueTask AddAsync(ContentTranslation contentTranslation)
        {
            await localizationDbContext.AddAsync(contentTranslation);
            await localizationDbContext.SaveChangesAsync();
        }

        public override async ValueTask<ContentTranslation> FindOneAsync(string cultureInfo, string key)
        {
            return await localizationDbContext.ContentTranslations.FirstOrDefaultAsync(w => w.Key == key && w.CultureInfo == cultureInfo);
        }
    }
}
