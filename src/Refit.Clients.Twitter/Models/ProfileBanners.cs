namespace Refit.Clients.Twitter.Models
{
    using System;
    using Newtonsoft.Json;

    public class ProfileBanners
    {
        public ProfileBannerSizes Sizes { get; set; }
    }

    public class ProfileBannerSizes
    {
        [JsonProperty("ipad")]
        public ProfileBannerSize iPad { get; set; }
        [JsonProperty("ipad_retina")]
        public ProfileBannerSize iPadRetina { get; set; }
        public ProfileBannerSize Web { get; set; }
        public ProfileBannerSize WebRetina { get; set; }
        public ProfileBannerSize Mobile { get; set; }
        public ProfileBannerSize MobileRetina { get; set; }
        [JsonProperty("300x100")]
        public ProfileBannerSize _300x100 { get; set; }
        [JsonProperty("600x200")]
        public ProfileBannerSize _600x200 { get; set; }
        [JsonProperty("1500x500")]
        public ProfileBannerSize _1500x500 { get; set; }
    }

    public class ProfileBannerSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Uri Url { get; set; }
    }
}
