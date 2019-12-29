namespace Refit.Clients.Twitter.Models.QueryParams
{
    using System;

    public class IDOrScreenNameQueryParams
    {
        private string _screenName;
        private ulong? _userId;

        [AliasAs("screen_name")]
        public string? ScreenName
        {
            get => !string.IsNullOrEmpty(this._screenName) ? this._screenName : string.Empty;
            set => this._screenName = value;
        }

        [AliasAs("user_id")]
        public string? UserID
        {
            get => this._userId.HasValue ? this._userId.ToString() : string.Empty;
            set => this._userId = Convert.ToUInt64(value);
        }
    }
}
