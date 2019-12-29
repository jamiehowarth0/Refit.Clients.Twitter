namespace Refit.Clients.Twitter.Models.Entities
{
    using Newtonsoft.Json;

    public class UrlEntity : EntityWithIndices
    {
        public string ExpandedUrl { get; set; }

        public string Url { get; set; }

        public string DisplayUrl { get; set; }

        [JsonProperty("unwound")]
        public ExtendedUrlEntity ExtendedProperties { get; set; }
    }
}
