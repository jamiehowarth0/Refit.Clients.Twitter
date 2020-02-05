// <copyright file="AdditionalMediaInfoEntity.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	public class AdditionalMediaInfoEntity
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public bool Embeddable { get; set; }

		public bool Monetizable { get; set; }
	}
}
