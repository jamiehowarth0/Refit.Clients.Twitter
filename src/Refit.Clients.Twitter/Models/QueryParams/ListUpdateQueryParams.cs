using System;
using System.Collections.Generic;
using System.Text;

namespace Refit.Clients.Twitter.Models.QueryParams
{
    public class UpdateListQueryParams
    {
        private ListMode _mode;
        [AliasAs("list_id")]
        public ulong ID { get; set; }
        [AliasAs("slug")]
        public string Slug { get; set; }
        [AliasAs("name")]
        public string Name { get; set; }
        [AliasAs("mode")]
        public string Mode
        {
            get => this._mode.ToString().ToLower();
            set => Enum.TryParse(value, out this._mode);
        }

        [AliasAs("description")]
        public string Description { get; set; }
        [AliasAs("owner_screen_name")]
        public string OwnerScreenName { get; set; }
        [AliasAs("owner_id")]
        public string OwnerID { get; set; }
    }
}
