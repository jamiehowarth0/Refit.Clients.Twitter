// <copyright file="UserMentions.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using Newtonsoft.Json;
using Refit.Clients.Twitter.Models.Entities;

namespace Refit.Clients.Twitter.Models
{
	public class UserMentions : EntityWithIndices
	{
		public string Name { get; set; }

		[JsonProperty("id_str")]
		public string IDString { get; set; }

		public ulong ID { get; set; }

		public string ScreenName { get; set; }
	}
}
