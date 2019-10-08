using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction
{
    public abstract class PersistenceProviderBase
    {
        public abstract Task AddAsync(ContentTranslation contentTranslation);

        public abstract Task UpdateAsync(ContentTranslation contentTranslation);

        public abstract Task DeleteAsync(ContentTranslation contentTranslation);

        public abstract Task<ContentTranslation> FindOneAsync(Expression<Func<ContentTranslation, bool>> predicate);

        public abstract Task<IEnumerable<ContentTranslation>> All(Expression<Func<ContentTranslation, bool>> predicate = null);
    }
}
