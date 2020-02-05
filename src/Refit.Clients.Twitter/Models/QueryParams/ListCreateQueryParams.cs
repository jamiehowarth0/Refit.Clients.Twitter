// <copyright file="ListCreateQueryParams.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Refit.Clients.Twitter.Models.QueryParams
{

	public class ListCreateQueryParams
	{
		private ListMode _mode;

		[AliasAs("name")]
		public string Name { get; set; }

		[AliasAs("mode")]
		public string Mode
		{
			get => _mode.ToString().ToLower();
			set => Enum.TryParse(value, out _mode);
		}

		[AliasAs("description")]
		public string Description { get; set; }
	}
}
