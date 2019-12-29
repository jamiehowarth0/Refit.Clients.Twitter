namespace Refit.Clients.Twitter.Models.QueryParams
{
    public class ListIDOrSlugQueryParams
    {
        [AliasAs("list_id")] public ulong? ListID { get; set; }
        [AliasAs("slug")] public string Slug { get; set; }
        [AliasAs("owner_screen_name")] public string OwnerScreenName { get; set; }
        [AliasAs("owner_id")] public string OwnerID { get; set; }
    }
}
