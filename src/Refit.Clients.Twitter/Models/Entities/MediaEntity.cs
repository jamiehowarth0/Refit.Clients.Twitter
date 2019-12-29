namespace Refit.Clients.Twitter.Models.Entities
{
    using System;
    using Newtonsoft.Json;

    public class MediaEntity : EntityWithIndices
    {
        public ulong ID { get; set; }
        [JsonProperty("id_str")]
        public string IDString { get; set; }
        public Uri MediaUrl { get; set; }
        public Uri MediaUrlHttps { get; set; }
        public Uri Url { get; set; }
        public Uri DisplayUrl { get; set; }
        public Uri ExpandedUrl { get; set; }
        public string Type { get; set; }
        public SizesEntity Sizes { get; set; }
        public VideoEntity VideoInfo { get; set; }
        public AdditionalMediaInfoEntity AdditionalMediaInfo { get; set; }
    }
}