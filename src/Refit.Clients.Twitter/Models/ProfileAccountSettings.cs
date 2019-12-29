namespace Refit.Clients.Twitter.Models
{
    using System;

    public class ProfileAccountSettings
    {
        private Uri _url;
        private bool? _includeEntities;
        private bool? _skipStatus;

        [AliasAs("name")]
        public string Name { get; set; }
        [AliasAs("url")]
        public string Url
        {
            get => this._url?.ToString();
            set => this._url = new Uri(value);
        }

        [AliasAs("location")]
        public string Location { get; set; }
        [AliasAs("description")]
        public string Description { get; set; }

        [AliasAs("include_entities")]
        public string IncludeEntit1ies
        {
            get => (this._includeEntities ?? true).ToString().ToLower();
            set => this._includeEntities = bool.Parse(value);
        }

        [AliasAs("skip_status")]
        public string SkipStatus
        {
            get => (this._skipStatus ?? true).ToString().ToLower();
            set => this._skipStatus = bool.Parse(value);
        }

        public static ProfileAccountSettings Default
        {
            get => new ProfileAccountSettings();
        }
    }
}
