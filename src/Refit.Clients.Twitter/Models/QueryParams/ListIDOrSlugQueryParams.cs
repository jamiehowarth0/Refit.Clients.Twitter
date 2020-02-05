using System;
using System.Diagnostics;
using System.Text;

namespace Refit.Clients.Twitter.Models.QueryParams
{
    public class ListIDOrSlugQueryParams
    {
        [AliasAs("list_id")] public ulong? ListID { get; set; }
        [AliasAs("slug")] public string Slug { get; set; }
        [AliasAs("owner_screen_name")] public string OwnerScreenName { get; set; }
        [AliasAs("owner_id")] public string OwnerID { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (ListID.HasValue)
            {
                sb.AppendFormat("list_id={0}", ListID.Value);
            }
            else
            {
                sb.Append("slug=");
                sb.Append(Slug);
                if (string.IsNullOrEmpty(OwnerScreenName) && string.IsNullOrEmpty(OwnerID))
                    throw new InvalidOperationException();
                if (!string.IsNullOrEmpty(OwnerID))
                {
                    sb.AppendFormat("&owner_id={0}", OwnerID);
                }
                else if (!string.IsNullOrEmpty(OwnerScreenName))
                {
                    sb.AppendFormat("&owner_screen_name={0}", OwnerScreenName);
                }
            }

            return sb.ToString();
        }
    }
}
