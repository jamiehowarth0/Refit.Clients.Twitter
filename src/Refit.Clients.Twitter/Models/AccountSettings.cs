using System.Collections.Generic;
using Newtonsoft.Json;
using Refit.Clients.Twitter.Models.Entities;

namespace Refit.Clients.Twitter.Models
{
	public class AccountSettings
	{
		public bool AlwaysUseHttps { get; set; }

		public bool DiscoverableByEmail { get; set; }

		public bool GeoEnabled { get; set; }

		public string Language { get; set; }

		[JsonProperty("_protected")]
		public bool Protected { get; set; }

		public string ScreenName { get; set; }

		public bool ShowAllInlineMedia { get; set; }

		public SleepTimeEntity SleepTime { get; set; }

		public TimeZoneEntity TimeZone { get; set; }

		public IEnumerable<TrendLocationEntity> TrendLocation { get; set; }

		public bool UseCookiePersonalization { get; set; }

		public string AllowContributorRequest { get; set; }
	}
}
