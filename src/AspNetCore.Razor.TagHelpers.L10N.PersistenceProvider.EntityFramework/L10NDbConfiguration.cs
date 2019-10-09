namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.EntityFramework
{
    public class L10NDbConfiguration
    {
        public string TableName { get; set; } = "ContentTranslation";
        public string Schema { get; set; }
    }
}
