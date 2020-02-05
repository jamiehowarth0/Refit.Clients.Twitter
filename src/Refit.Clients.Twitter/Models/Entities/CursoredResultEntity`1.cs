// <copyright file="CursoredResultEntity`1.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.Entities
{
	public abstract class CursoredResultEntity<T>
		where T : class
	{
		public ulong NextCursor { get; set; }
		public string NextCursorStr { get; set; }
		public ulong PreviousCursor { get; set; }
		public string PreviousCursorStr { get; set; }
		public ulong? TotalCount { get; set; }
	}
}
