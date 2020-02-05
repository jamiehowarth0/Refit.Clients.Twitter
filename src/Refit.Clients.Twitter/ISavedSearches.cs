// <copyright file="ISavedSearches.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter
{
	using System.Threading.Tasks;
	using Refit;

	[Headers("Authorization: OAuth")]
	public interface ISavedSearches
	{
		[Get("/saved_searches/list.json")]
		Task List();

		[Get("/saved_searches/show/{id}.json")]
		Task Show([AliasAs("id")]ulong savedSearchId);

		[Post("/saved_searches/create.json")]
		Task Create();

		[Post("/saved_searches/destroy/{id}.json")]
		Task Destroy([AliasAs("id")]ulong savedSearchId);
	}
}
