using System;
using System.Globalization;
using System.Linq;
using Refit;

namespace Refit.Clients.Twitter.Models.QueryParams
{
	public class TweetQueryParams
	{
		private ulong? _inReplyToStatusID;
		private ulong[] _excludeReplyUserIDs;
		private ulong[] _mediaIDs;
		private double? _latitude;
		private double? _longitude;
		private bool? _autoPopulateReplyMetadata;
		private bool? _possibleSensitive;
		private bool? _displayCoordinates;
		private bool? _enableDmCommands;
		private bool? _failDmCommands;
		private bool? _trimUser;

		[AliasAs("status")]
		public string Status { get; set; }

		[AliasAs("in_reply_to_status_id")]
		public string InReplyToStatusID
		{
			get => _inReplyToStatusID.ToString();
			set => _inReplyToStatusID = UInt64.Parse(value);
		}

		[AliasAs("auto_populate_reply_metadata")]
		public string AutoPopulateReplyMetadata
		{
			get => (_autoPopulateReplyMetadata ?? false).ToString().ToLower();
			set => _autoPopulateReplyMetadata = bool.Parse(value);
		}

		[AliasAs("exclude_reply_user_ids")]
		public string ExcludeReplyUserIDs
		{
			get => _excludeReplyUserIDs != null && _excludeReplyUserIDs.Any() ? string.Join(",", _excludeReplyUserIDs) : string.Empty;
			set => _excludeReplyUserIDs = value.Split(',').Select(x => Convert.ToUInt64(x)).ToArray();
		}

		[AliasAs("attachment_url")]
		public string AttachmentUrl { get; set; }

		[AliasAs("media_ids")]
		public string MediaIDs
		{
			get => _mediaIDs != null && _mediaIDs.Any() ? string.Join(",", _mediaIDs) : string.Empty;
			set => _mediaIDs = value.Split(',').Select(x => Convert.ToUInt64(x)).ToArray();
		}

		[AliasAs("possibly_sensitive")]
		public string PossiblySensitive
		{
			get => (_possibleSensitive ?? false).ToString().ToLower();
			set => _possibleSensitive = bool.Parse(value);
		}

		[AliasAs("lat")]
		public string Latitude { get; set; }

		[AliasAs("long")]
		public string Longitude { get; set; }

		[AliasAs("place_id")]
		public string PlaceID { get; set; }

		[AliasAs("display_coordinates")]
		public string DisplayCoordinates
		{
			get => (_displayCoordinates ?? false).ToString().ToLower();
			set => _displayCoordinates = bool.Parse(value);
		}

		[AliasAs("trim_user")]
		public string TrimUser
		{
			get => (_trimUser ?? false).ToString().ToLower();
			set => _trimUser = bool.Parse(value);
		}

		[AliasAs("enable_dmcommands")]
		public string EnableDMCommands
		{
			get => (_enableDmCommands ?? false).ToString(CultureInfo.DefaultThreadCurrentCulture).ToLower();
			set => _enableDmCommands = bool.Parse(value);
		}

		[AliasAs("fail_dmcommands")]
		public string FailDMCommands
		{
			get => (_failDmCommands ?? true).ToString(CultureInfo.DefaultThreadCurrentCulture).ToLower();
			set => _failDmCommands = bool.Parse(value);
		}

		[AliasAs("card_uri")]
		public string CardUri { get; set; }
	}
}
