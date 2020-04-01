using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refit.Clients.Twitter.Models.QueryParams
{
    public class ListMemberCRUDAllQueryParams : ListIDOrSlugQueryParams
    {
        [AliasAs("user_id")]
        public ulong[] UserID { get; set; }

        [AliasAs("screen_name")]
        public string[] ScreenName { get; set; }

        public override string ToString()
        {
            var result = base.ToString();
            if (UserID.Any())
            {
                result += $"&user_id={string.Join(",", UserID)}";
            } else if (ScreenName.Any())
            {
                result += $"&screen_name={string.Join(",", ScreenName)}";
            }
            else
            {
                throw new ArgumentNullException();
            }

            return result;
        }
    }
}
