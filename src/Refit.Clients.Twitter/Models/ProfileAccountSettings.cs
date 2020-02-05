using System;
using System.Globalization;

namespace Refit.Clients.Twitter.Models
{
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
			get => _url?.ToString();
			set => _url = new Uri(value);
		}

		[AliasAs("location")]
		public string Location { get; set; }

		[AliasAs("description")]
		public string Description { get; set; }

		[AliasAs("include_entities")]
		public string IncludeEntit1ies
		{
			get => (_includeEntities ?? true).ToString(CultureInfo.DefaultThreadCurrentCulture).ToLower();
			set => _includeEntities = bool.Parse(value);
		}

		[AliasAs("skip_status")]
		public string SkipStatus
		{
			get => (_skipStatus ?? true).ToString(CultureInfo.DefaultThreadCurrentCulture).ToLower();
			set => _skipStatus = bool.Parse(value);
		}

		public static ProfileAccountSettings Default
		{
			get => new ProfileAccountSettings();
		}
	}
}
