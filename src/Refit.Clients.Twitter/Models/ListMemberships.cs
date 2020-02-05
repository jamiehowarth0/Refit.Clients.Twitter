// <copyright file="ListMemberships.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using Refit.Clients.Twitter.Models.Entities;

namespace Refit.Clients.Twitter.Models
{
	public class ListMemberships : CursoredResultEntity<UserList>
	{
		public IEnumerable<UserList> Lists { get; set; }
	}
}
