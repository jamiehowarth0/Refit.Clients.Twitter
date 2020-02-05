// <copyright file="ProfileBannerQueryParams.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.QueryParams
{
	public class ProfileBannerQueryParams
	{
		[AliasAs("width")]
		public int? Width { get; set; }

		[AliasAs("height")]
		public int? Height { get; set; }

		[AliasAs("offset_left")]
		public int? OffsetLeft { get; set; }

		[AliasAs("offset_top")]
		public int? OffsetTop { get; set; }
	}
}
