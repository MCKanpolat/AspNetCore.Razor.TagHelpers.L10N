using AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.EntityFramework
{
    public class ContentTranslationEntity : ContentTranslation
    {
        public int Id { get; set; }
    }
}
