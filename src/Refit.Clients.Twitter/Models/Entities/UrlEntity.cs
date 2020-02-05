// <copyright file="UrlEntity.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using Newtonsoft.Json;

namespace Refit.Clients.Twitter.Models.Entities
{
	public class UrlEntity : EntityWithIndices
	{
		public string ExpandedUrl { get; set; }

		public string Url { get; set; }

		public string DisplayUrl { get; set; }

		[JsonProperty("unwound")]
		public ExtendedUrlEntity ExtendedProperties { get; set; }
	}
}
