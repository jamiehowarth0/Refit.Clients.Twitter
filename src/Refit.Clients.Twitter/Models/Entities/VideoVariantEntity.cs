// <copyright file="VideoVariantEntity.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	using System;

	public class VideoVariantEntity
	{
		public int Bitrate { get; set; }
		public string ContentType { get; set; }
		public Uri Url { get; set; }
	}
}