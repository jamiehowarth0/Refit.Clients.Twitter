// <copyright file="VideoEntity.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	using Newtonsoft.Json;

	public class VideoEntity
	{
		public int[] AspectRatio { get; set; }
		[JsonProperty("duration_millis")]
		public int DurationMilliseconds { get; set; }
		public VideoVariantEntity[] Variants { get; set; }
	}
}