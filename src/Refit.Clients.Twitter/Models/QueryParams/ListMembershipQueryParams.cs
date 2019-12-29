namespace Refit.Clients.Twitter.Models.QueryParams
{
    public class ListMembershipQueryParams : CountCursorQueryParams
    {
        [AliasAs("filter_to_owned_lists")]
        public bool? FilterToOwnedLists { get; set; }
    }
}
