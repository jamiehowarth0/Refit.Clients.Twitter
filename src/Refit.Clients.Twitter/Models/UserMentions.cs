namespace Refit.Clients.Twitter.Models
{
    using Newtonsoft.Json;
    using Refit.Clients.Twitter.Models.Entities;

    public class UserMentions : EntityWithIndices
    {
        public string Name { get; set; }
        [JsonProperty("id_str")]
        public string IDString { get; set; }
        public ulong ID { get; set; }
        public string ScreenName { get; set; }
    }
}