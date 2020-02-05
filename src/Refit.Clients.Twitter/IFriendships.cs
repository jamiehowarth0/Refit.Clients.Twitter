// <copyright file="IFriendships.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Refit.Clients.Twitter
{

	[Headers("Authorization: OAuth")]
	public interface IFriendships
	{
		[Get("/friends/ids.json")]
		Task GetByIds();

		[Get("/friends/list.json")]
		Task List();

		[Get("/friendships/incoming.json")]
		Task Incoming();

		[Get("/friendships/outgoing.json")]
		Task Outgoing();

		[Get("/friendships/lookup.json")]
		Task Lookup();

		[Get("/friendships/show.json")]
		Task Show();

		[Get("/friendships/no_retweets/ids.json")]
		Task<IEnumerable<int>> NoRetweets();

		[Post("/friendships/create.json")]
		Task Create();

		[Post("/friendships/destroy.json")]
		Task Destroy();

		[Post("/friendships/update.json")]
		Task Update();

		//GET friendships/no_retweets/ids
		//GET friendships/show
		
		//GET followers/ids
		//GET followers/list

	}
}
