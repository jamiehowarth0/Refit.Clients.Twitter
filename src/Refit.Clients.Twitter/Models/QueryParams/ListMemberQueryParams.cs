// <copyright file="ListMemberQueryParams.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using System;

namespace Refit.Clients.Twitter.Models.QueryParams
{

	public class ListMemberQueryParams
	{
		private string _screenName;
		private ulong? _userId;

		/// <summary>
		/// Gets or sets the numerical ID of the list.
		/// </summary>
		[AliasAs("list_id")]
		public ulong ListID { get; set; }

		/// <summary>
		/// Gets or sets the list slug. You can identify a list by its slug instead of its numerical id. If you decide to do so, note that you'll also have to specify the list owner using the owner_id or owner_screen_name parameters.
		/// </summary>
		[AliasAs("slug")]
		public string Slug { get; set; }

		/// <summary>
		/// Gets or sets the screen name of the user who owns the list being requested by a slug.
		/// </summary>
		[AliasAs("owner_screen_name")]
		public string OwnerScreenName { get; set; }

		/// <summary>
		/// Gets or sets the user ID of the user who owns the list being requested by a slug.
		/// </summary>
		[AliasAs("owner_id")]
		public ulong? OwnerID { get; set; }

		/// <summary>
		/// Gets or sets the screen name of the user for whom to return results. Helpful for disambiguating when a valid screen name is also a user ID.
		/// </summary>
		[AliasAs("screen_name")]
		public string ScreenName
		{
			get => !string.IsNullOrEmpty(_screenName) ? _screenName : string.Empty;
			set => _screenName = value;
		}

		/// <summary>
		/// Gets or sets the ID of the user for whom to return results. Helpful for disambiguating when a valid user ID is also a valid screen name.
		/// </summary>
		[AliasAs("user_id")]
		public string UserID
		{
			get => _userId.HasValue ? _userId.ToString() : string.Empty;
			set => _userId = Convert.ToUInt64(value);
		}

		/// <summary>
		/// Gets or sets whether to return entities. The entities node will not be included when set to false.
		/// </summary>
		[AliasAs("include_entities")]
		public bool IncludeEntities { get; set; }

		/// <summary>
		/// Gets or sets the skip_status parameter. When set to true, statuses will not be included in the returned user objects.
		/// </summary>
		[AliasAs("skip_status")]
		public bool SkipStatus { get; set; }
	}
}
