// <copyright file="Tweet.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using System;
using Newtonsoft.Json;
using Refit.Clients.Twitter.Models.Entities;

namespace Refit.Clients.Twitter.Models
{
	public class Tweet
	{
		public CoordinatesEntity Coordinates { get; set; }

		public bool Truncated { get; set; }

		public DateTime CreatedAt { get; set; }

		public bool Favorited { get; set; }

		[JsonProperty("id_str")]
		public string IdString { get; set; }

		[JsonProperty("in_reply_to_user_id_str")]
		public string InReplyToUserIdString { get; set; }

		public EntitiesContainer Entities { get; set; }

		public string Text { get; set; }

		public object Contributors { get; set; }

		public ulong ID { get; set; }

		public int RetweetCount { get; set; }

		[JsonProperty("in_reply_to_status_id_str")]
		public string InReplyToStatusIdString { get; set; }

		public GeoEntity Geo { get; set; }

		public bool Retweeted { get; set; }

		public bool PossiblySensitive { get; set; }

		public ulong? InReplyToUserId { get; set; }

		public PlaceEntity Place { get; set; }

		public string Source { get; set; }

		public User User { get; set; }

		public string InReplyToScreenName { get; set; }

		public ulong? InReplyToStatusId { get; set; }
	}
}
