using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction
{
    public abstract class PersistenceProviderBase
    {
        public abstract ValueTask AddAsync(ContentTranslation contentTranslation);

        public abstract ValueTask<ContentTranslation> FindOneAsync(string cultureInfo, string key);
    }
}
