// <copyright file="EntityWithIndices.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Refit.Clients.Twitter.Models.Entities
{
	public abstract class EntityWithIndices
	{
		public IEnumerable<int> Indices { get; set; }
	}
}
