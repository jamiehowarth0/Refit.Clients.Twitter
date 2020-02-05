// <copyright file="SizesEntity.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	public class SizesEntity
	{
		public MediaSizesEntity Medium { get; set; }

		public MediaSizesEntity Small { get; set; }

		public MediaSizesEntity Thumb { get; set; }

		public MediaSizesEntity Large { get; set; }
	}
}
