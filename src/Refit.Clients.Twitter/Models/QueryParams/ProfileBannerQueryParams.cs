namespace Refit.Clients.Twitter.Models.QueryParams
{
    public class ProfileBannerQueryParams
    {
        [AliasAs("width")]
        public int? Width { get; set; }
        [AliasAs("height")]
        public int? Height { get; set; }
        [AliasAs("offset_left")]
        public int? OffsetLeft { get; set; }
        [AliasAs("offset_top")]
        public int? OffsetTop { get; set; }
    }
}
