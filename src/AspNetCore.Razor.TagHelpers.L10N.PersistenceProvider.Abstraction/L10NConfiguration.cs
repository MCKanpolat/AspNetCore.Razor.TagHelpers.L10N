namespace AspNetCore.Razor.TagHelpers.L10N
{
    public class L10NConfiguration
    {
        public string ContentNotFoundText { get; set; } = "No Content Avaliable For {Culture} Key {Key}";
        public bool AutoInsertWhenNotFound { get; set; }
    }
}
