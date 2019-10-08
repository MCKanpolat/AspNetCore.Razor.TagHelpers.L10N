using AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.EntityFramework
{
    public class ContentTranslationEntity : ContentTranslation
    {
        public int Id { get; set; }
    }
}
