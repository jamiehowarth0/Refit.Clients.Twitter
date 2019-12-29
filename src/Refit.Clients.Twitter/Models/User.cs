namespace Refit.Clients.Twitter.Models
{
    using System;
    using Newtonsoft.Json;
    using Refit.Clients.Twitter.Models.Entities;

    public class User
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Location { get; set; }
        public bool FollowRequestSent { get; set; }
        [JsonProperty("id_str")]
        public string IDString { get; set; }
        public bool IsTranslator { get; set; }
        public EntitiesContainer Entities { get; set; }
        public bool DefaultProfile { get; set; }
        public string Url { get; set; }
        public bool ContributorsEnabled { get; set; }
        public int FavouritesCount { get; set; }
        public int? UTCOffset { get; set; }
        public ulong ID { get; set; }
        public int ListedCount { get; set; }
        public int FollowersCount { get; set; }
        [JsonProperty("lang")]
        public string Language { get; set; }
        [JsonProperty("_protected")]
        public bool Protected { get; set; }
        public bool GeoEnabled { get; set; }
        public bool Notifications { get; set; }
        public string Description { get; set; }
        public bool Verified { get; set; }
        public string Timezone { get; set; }
        public int StatusesCount { get; set; }
        public int FriendsCount { get; set; }
        public bool Following { get; set; }
        public bool ShowAllInlineMedia { get; set; }
        public string ScreenName { get; set; }

        public string ProfileBackgroundColor { get; set; }
        public string ProfileLinkColor { get; set; }
        public string ProfileSidebarBorderColor { get; set; }
        public string ProfileSidebarFillColor { get; set; }
        public string ProfileTextColor { get; set; }
        public bool ProfileBackgroundTile { get; set; }
        public bool ProfileUseBackgroundImage { get; set; }
        public string ProfileImageUrlHttps { get; set; }
        [Obsolete("Use ProfileBackgroundImageHttps, it's more secure", true)]
        public string ProfileBackgroundImageUrl { get; set; }
        public string ProfileBackgroundImageUrlHttps { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool DefaultProfileImage { get; set; }
    }
}