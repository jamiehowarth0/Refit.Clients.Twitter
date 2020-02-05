// <copyright file="IDOrScreenNameQueryParams.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

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
