using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction
{
    public interface ILocalizationService
    {
        Task<IEnumerable<ContentTranslation>> GetContentTranslationsAsync();
        Task<ContentTranslation> GetContentTranslationAsync(string cultureInfo, string key, string defaultContent = null);
    }
}
