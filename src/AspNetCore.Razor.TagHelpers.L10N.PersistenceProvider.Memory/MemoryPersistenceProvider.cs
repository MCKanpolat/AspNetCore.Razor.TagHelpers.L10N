using AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Custom
{
    public class MemoryPersistenceProvider : PersistenceProviderBase
    {
        private readonly List<ContentTranslation> stubData;

        public MemoryPersistenceProvider()
        {
            stubData = new List<ContentTranslation>();
            stubData.Add(new ContentTranslation() { CultureInfo = "tr-TR", Key = "lbl.hello", Content = "Merhaba" });
            stubData.Add(new ContentTranslation() { CultureInfo = "en-US", Key = "lbl.hello", Content = "Hello" });
        }

        public override ValueTask AddAsync(ContentTranslation contentTranslation)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<ContentTranslation> FindOneAsync(string cultureInfo, string key)
        {
            var result = stubData.FirstOrDefault(w => w.CultureInfo == cultureInfo && w.Key == key);
            return new ValueTask<ContentTranslation>(result);
        }
    }
}
