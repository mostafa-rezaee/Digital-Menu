using Common.Domain;

namespace Common.Domain.ValueObjects
{
    public class SeoData
    {
        private SeoData() { }
        public static SeoData MakeEmpty()
        {
            return new SeoData();
        }
        public SeoData(string metaDescription, string metaTitle, string metaKeywords, bool isIndexed, string canonicial, string schema)
        {
            MetaDescription = metaDescription;
            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            IsIndexed = isIndexed;
            Canonicial = canonicial;
            Schema = schema;
        }

        public string MetaDescription { get; private set; }
        public string MetaTitle { get; private set; }
        public string MetaKeywords { get; private set; }
        public bool IsIndexed { get; private set; }
        public string Canonicial { get; private set; }
        public string Schema { get; private set; }

    }
}
