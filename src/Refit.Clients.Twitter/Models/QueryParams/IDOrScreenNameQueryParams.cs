namespace Refit.Clients.Twitter.Models.QueryParams
{
	using System;

	public class IDOrScreenNameQueryParams
	{
		private string _screenName;
		private ulong? _userId;

		[AliasAs("screen_name")]
		public string ScreenName
		{
			get => !string.IsNullOrEmpty(_screenName) ? _screenName : string.Empty;
			set => _screenName = value;
		}

		[AliasAs("user_id")]
		public string? UserID
		{
			get => _userId.HasValue ? _userId.ToString() : string.Empty;
			set => _userId = Convert.ToUInt64(value);
		}
	}
}
