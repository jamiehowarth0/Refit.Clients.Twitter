// <copyright file="ListMembers.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models
{
	using System.Collections.Generic;
	using Refit.Clients.Twitter.Models.Entities;
	public class ListMembers : CursoredResultEntity<User>
	{
		public IEnumerable<User> Users { get; set; }
	}
}
