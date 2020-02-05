// <copyright file="MediaSizesEntity.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using Newtonsoft.Json;

namespace Refit.Clients.Twitter.Models.Entities
{
	public class MediaSizesEntity
	{
		[JsonProperty("w")]
		public int Width { get; set; }

		[JsonProperty("h")]
		public int Height { get; set; }

		[JsonProperty("resize")]
		public string ResizeMode { get; set; }
	}
}
