using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction
{
    public interface ILocalizationService
    {
        ValueTask<ContentTranslation> GetContentTranslationAsync(string cultureInfo, string key, string defaultContent = null);
    }
}
