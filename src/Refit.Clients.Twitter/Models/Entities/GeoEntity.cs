// <copyright file="GeoEntity.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	public class GeoEntity
	{
		public float[] Coordinates { get; set; }
		public string Type { get; set; }
	}
}