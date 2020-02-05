// <copyright file="WoeID.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	public class WoeID
	{
		[AliasAs("country")]
		public string Country { get; set; }
		[AliasAs("countryCode")]
		public string CountryCode { get; set; }
		public string Name { get; set; }
		[AliasAs("parentId")]
		public int ParentID { get; set; }
		[AliasAs("placeType")]
		public PlacetypeEntity PlaceType { get; set; }
		public string Url { get; set; }
		[AliasAs("woeid")]
		public int WOEID { get; set; }
	}
}
