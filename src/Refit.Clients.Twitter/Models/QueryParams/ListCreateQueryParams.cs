namespace Refit.Clients.Twitter.Models.QueryParams
{
    using System;

    public class ListCreateQueryParams
    {
        private ListMode _mode;
        public string Name { get; set; }

        public string Mode
        {
            get => this._mode.ToString().ToLower();
            set => Enum.TryParse(value, out this._mode);
        }
        public string Description { get; set; }

        enum ListMode
        {
            Private,
            Public
        }
    }
}
