using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Refit.Clients.Twitter.Models.QueryParams
{
	public class ListMemberCRUDQueryParams : ListIDOrSlugQueryParams
	{
		[AliasAs("user_id")]
		public ulong? UserID { get; set; }

		[AliasAs("screen_name")]
		public string ScreenName { get; set; }

		public override string ToString()
		{
			var result = base.ToString();
			if (UserID.HasValue)
			{
				result += $"&user_id={UserID}";
			} else if (!string.IsNullOrEmpty(ScreenName))
			{
				result += $"&screen_name={ScreenName}";
			}
			else
			{
				throw new ArgumentNullException();
			}

			return result;
		}
	}
}
