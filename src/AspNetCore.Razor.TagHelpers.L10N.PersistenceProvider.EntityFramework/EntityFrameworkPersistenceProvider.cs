using AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public override async Task AddAsync(ContentTranslation contentTranslation)
        {
            await localizationDbContext.AddAsync(contentTranslation);
            await localizationDbContext.SaveChangesAsync();
        }

        public override async Task<IEnumerable<ContentTranslation>> All(Expression<Func<ContentTranslation, bool>> predicate = null)
        {
            return predicate != null
                ? await localizationDbContext.ContentTranslations.AsNoTracking().Where(predicate).ToListAsync()
               : await localizationDbContext.ContentTranslations.AsNoTracking().ToListAsync();
        }

        public override async Task<ContentTranslation> FindOneAsync(Expression<Func<ContentTranslation, bool>> predicate)
        {
            return await localizationDbContext.ContentTranslations.FirstOrDefaultAsync(predicate);
        }
    }
}
