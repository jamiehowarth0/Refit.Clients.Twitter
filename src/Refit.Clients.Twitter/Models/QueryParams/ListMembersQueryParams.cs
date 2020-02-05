namespace Refit.Clients.Twitter.Models.QueryParams
{
	public class ListMembersQueryParams
	{
		/// <summary>
		/// Gets or sets the numerical id of the list.
		/// </summary>
		[AliasAs("list_id")]
		public ulong ListID { get; set; }

		/// <summary>
		/// Gets or sets the list identified by its slug instead of its numerical id. If you decide to do so, note that you'll also have to specify the list owner using the owner_id or owner_screen_name parameters.
		/// </summary>
		[AliasAs("slug")]
		public string Slug { get; set; }

		/// <summary>
		/// Gets or sets the screen name of the user who owns the list being requested by a slug.
		/// </summary>
		[AliasAs("owner_screen_name")]
		public string OwnerScreenName { get; set; }

		/// <summary>
		/// Gets or sets the user ID of the user who owns the list being requested by a slug.
		/// </summary>
		[AliasAs("owner_id")]
		public ulong? OwnerID { get; set; }

		/// <summary>
		/// Gets or sets the number of results to return per page (see cursor below). The default is 20, with a maximum of 5,000.
		/// </summary>
		[AliasAs("count")]
		public ulong? Count { get; set; }

		/// <summary>
		/// Gets or sets a cursor property, which causes the collection of list members to be broken into "pages" of consistent sizes (specified by the count parameter). If no cursor is provided, a value of -1 will be assumed, which is the first "page."
		/// </summary>
		[AliasAs("cursor")]
		public ulong? Cursor { get; set; }

		/// <summary>
		/// Gets or sets the response from the API that could include a previous_cursor and next_cursor to allow paging back and forth.
		/// </summary>
		[AliasAs("previous_cursor")]
		public ulong? PreviousCursor { get; set; }

		/// <summary>
		/// Gets or sets the response from the API that could include a previous_cursor and next_cursor to allow paging back and forth.
		/// </summary>
		[AliasAs("next_cursor")]
		public ulong? NextCursor { get; set; }

		/// <summary>
		/// Gets or sets whether entities should be included. Defaults to "true".
		/// </summary>
		[AliasAs("include_entities")]
		public bool IncludeEntities { get; set; }

		/// <summary>
		/// Gets or sets whether statuses will be included in the returned user objects. Defaults to "false".
		/// </summary>
		[AliasAs("skip_status")]
		public bool SkipStatus { get; set; }
	}
}
