// <copyright file="EntitiesContainer.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	public class EntitiesContainer
	{
		public UrlEntity[] Urls { get; set; }
		public HashTagEntity[] Hashtags { get; set; }
		public UserMentions[] UserMentions { get; set; }
		public SymbolEntity[] Symbols { get; set; }
		public MediaEntity[] Media { get; set; }
	}
}
