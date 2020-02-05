// <copyright file="TimeZoneEntity.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	public class TimeZoneEntity
	{
		public string Name { get; set; }
		public string TZInfoName { get; set; }
		public int UTCOffset { get; set; }
	}
}