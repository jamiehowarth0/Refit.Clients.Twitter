// <copyright file="UserTimelineQueryParams.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.QueryParams
{
	using System;

	public class UserTimelineQueryParams
	{
		private bool? _includeEntities;
		private int? _page;

		[AliasAs("include_entities")]
		public string IncludeEntities
		{
			get => _includeEntities.HasValue ? _includeEntities.Value.ToString().ToLowerInvariant() : Boolean.TrueString.ToLowerInvariant();
			set => _includeEntities = bool.Parse(value);
		}

		[AliasAs("page")]
		public string Page
		{
			get => _page.HasValue ? _page.Value.ToString() : "1";
			set => _page = int.Parse(value);
		}

		public static UserTimelineQueryParams Default
		{
			get => new UserTimelineQueryParams();
		}
	}
}
