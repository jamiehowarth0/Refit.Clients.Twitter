namespace Refit.Clients.Twitter.Models.QueryParams
{
    using System;

    public class UserTimelineQueryParams
    {
        private bool? _includeEntities;
        private int? _page;

        [AliasAs("include_entities")]
        public string IncludeEntities
        {
            get => this._includeEntities.HasValue ? this._includeEntities.Value.ToString().ToLowerInvariant() : Boolean.TrueString.ToLowerInvariant();
            set => this._includeEntities = bool.Parse(value);
        }

        [AliasAs("page")]
        public string Page
        {
            get => this._page.HasValue ? this._page.Value.ToString() : "1";
            set => this._page = int.Parse(value);
        }

        public static UserTimelineQueryParams Default
        {
            get => new UserTimelineQueryParams();
        }
    }
}