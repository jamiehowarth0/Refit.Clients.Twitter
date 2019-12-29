namespace Refit.Clients.Twitter
{
    using System;

    public class ListMemberQueryParams
    {
        private string _screenName;
        private ulong? _userId;

        /// <summary>
        /// The numerical id of the list.
        /// </summary>
        [AliasAs("list_id")]
        public ulong ListID { get; set; }
        /// <summary>
        /// You can identify a list by its slug instead of its numerical id. If you decide to do so, note that you'll also have to specify the list owner using the owner_id or owner_screen_name parameters.
        /// </summary>
        [AliasAs("slug")]
        public string Slug { get; set; }
        /// <summary>
        /// The screen name of the user who owns the list being requested by a slug.
        /// </summary>
        [AliasAs("owner_screen_name")]
        public string OwnerScreenName { get; set; }
        /// <summary>
        /// The user ID of the user who owns the list being requested by a slug.
        /// </summary>
        [AliasAs("owner_id")]
        public ulong? OwnerID { get; set; }

        /// <summary>
        /// The screen name of the user for whom to return results. Helpful for disambiguating when a valid screen name is also a user ID.
        /// </summary>
        [AliasAs("screen_name")]
        public string ScreenName
        {
            get => !string.IsNullOrEmpty(this._screenName) ? this._screenName : string.Empty;
            set => this._screenName = value;
        }

        /// <summary>
        /// The ID of the user for whom to return results. Helpful for disambiguating when a valid user ID is also a valid screen name.
        /// </summary>
        [AliasAs("user_id")]
        public string UserID
        {
            get => this._userId.HasValue ? this._userId.ToString() : string.Empty;
            set => this._userId = Convert.ToUInt64(value);
        }
        /// <summary>
        /// The entities node will not be included when set to false.
        /// </summary>
        [AliasAs("include_entities")]
        public bool IncludeEntities { get; set; }
        /// <summary>
        /// When set to either true, t or 1 statuses will not be included in the returned user objects.
        /// </summary>
        [AliasAs("skip_status")]
        public bool SkipStatus { get; set; }
    }
}