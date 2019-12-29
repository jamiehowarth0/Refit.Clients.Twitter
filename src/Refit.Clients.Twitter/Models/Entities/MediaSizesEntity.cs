namespace Refit.Clients.Twitter.Models.Entities
{
    using Newtonsoft.Json;

    public class MediaSizesEntity
    {
        [JsonProperty("w")]
        public int Width { get; set; }
        [JsonProperty("h")]
        public int Height { get; set; }
        [JsonProperty("resize")]
        public string ResizeMode { get; set; }
    }
}