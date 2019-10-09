using AspNetCore.Razor.TagHelpers.L10N.Abstraction;
using System.Threading;

namespace AspNetCore.Razor.TagHelpers.L10N
{
    public class DefaultLocalizationServiceCultureAccessor : ILocalizationServiceCultureAccessor
    {
        public string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentUICulture.Name;
        }
    }
}
