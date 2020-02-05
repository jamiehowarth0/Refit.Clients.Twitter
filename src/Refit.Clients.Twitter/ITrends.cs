// <copyright file="ITrends.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using System.Collections.Generic;
using Refit.Clients.Twitter.Models.Entities;

namespace Refit.Clients.Twitter
{
	[Headers("Authorization: OAuth")]
	public interface ITrends
	{
		[Get("/trends/available.json")]
		IEnumerable<WoeID> Available();

		[Get("/trends/closest.json")]
		IEnumerable<WoeID> Closest([Query] LocationQueryParams location);
	}
}
