// <copyright file="BlockUserQueryParams.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter.Models.QueryParams
{
	using System;

	public class BlockUserQueryParams : IDOrScreenNameQueryParams
	{
		private bool? _performBlock;

		[AliasAs("perform_block")]
		public string PerformBlock
		{
			get => _performBlock.HasValue ? _performBlock.Value.ToString().ToLowerInvariant() : bool.TrueString.ToLowerInvariant();
			set => _performBlock = bool.Parse(value);
		}
	}
}
