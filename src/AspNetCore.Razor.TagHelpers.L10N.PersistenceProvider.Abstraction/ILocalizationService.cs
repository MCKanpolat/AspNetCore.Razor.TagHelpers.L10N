using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.Abstraction
{
    public interface ILocalizationService
    {
        ValueTask<ContentTranslation> GetContentTranslationAsync(string cultureInfo, string key, string defaultContent = null);
    }
}
