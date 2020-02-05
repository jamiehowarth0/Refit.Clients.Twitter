// <copyright file="LocationQueryParams.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter
{
	public class LocationQueryParams
	{
		public decimal Latitude { get; set; }

		public decimal Longitude { get; set; }
	}
}
