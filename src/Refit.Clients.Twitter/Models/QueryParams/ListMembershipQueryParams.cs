// <copyright file="ListMembershipQueryParams.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.QueryParams
{
	public class ListMembershipQueryParams : CountCursorQueryParams
	{
		[AliasAs("filter_to_owned_lists")]
		public bool? FilterToOwnedLists { get; set; }
	}
}
