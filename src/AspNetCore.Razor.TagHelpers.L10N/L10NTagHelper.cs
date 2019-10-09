using AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N
{
    [HtmlTargetElement("locale", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class L10NTagHelper : TagHelper
    {
        private readonly ILocalizationService LocalizationService;
        private readonly ILocalizationServiceCultureAccessor localizationServiceCultureAccessor;
        private readonly IOptions<L10NConfiguration> l10NConfiguration;

        public L10NTagHelper(ILocalizationService localizationService, ILocalizationServiceCultureAccessor localizationServiceCultureAccessor,
            IOptions<L10NConfiguration> l10NConfiguration)
        {
            LocalizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            this.localizationServiceCultureAccessor = localizationServiceCultureAccessor ?? throw new ArgumentNullException(nameof(localizationServiceCultureAccessor));
            this.l10NConfiguration = l10NConfiguration ?? throw new ArgumentNullException(nameof(l10NConfiguration));
        }

        [HtmlAttributeName("Key")]
        public string Key { get; set; }

        [HtmlAttributeName("SurroundTag")]
        public string SurroundTag { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var currentContent = await output.GetChildContentAsync();
            var currentCulture = localizationServiceCultureAccessor.GetCurrentCulture();
            var translation = await LocalizationService.GetContentTranslationAsync(currentCulture, Key, currentContent.GetContent());
            SetContent(currentCulture, translation, output);
        }

        private void SetContent(string currentCulture, ContentTranslation contentTranslation, TagHelperOutput output)
        {
            if (contentTranslation != null)
            {
                output.Content.SetHtmlContent(contentTranslation.Content);
            }
            else
            {
                output.Content.SetHtmlContent(l10NConfiguration.Value.ContentNotFoundText?.Replace("{Culture}", currentCulture).Replace("{Key}", Key));
            }
            output.TagName = !string.IsNullOrWhiteSpace(SurroundTag) ? SurroundTag : null;
        }
    }
}
