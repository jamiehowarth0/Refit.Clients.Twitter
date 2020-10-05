// <copyright file="IStatuses.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Refit.Clients.Twitter
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Refit;
	using Refit.Clients.Twitter.Models;
	using Refit.Clients.Twitter.Models.QueryParams;

	[Headers("Authorization: OAuth")]
	public interface IStatuses
	{
		[Post("/statuses/update.json")]
		Task<Tweet> Post([Query]TweetQueryParams tweet);

		[Post("/statuses/destroy/{id}.json")]
		Task<Tweet> Delete([AliasAs("id")]ulong tweetId);

		[Get("/statuses/show/{id}.json")]
		Task<Tweet> Get([AliasAs("id")]ulong tweetId);

		[Get("/statuses/lookup.json")]
		Task<IEnumerable<Tweet>> Lookup([Query]LookupQueryParams searchParams);

		[Post("/statuses/retweet/{id}.json")]
		Task<Tweet> Retweet(ulong id);

		[Post("/statuses/unretweet/{id}.json")]
		Task<Tweet> Unretweet(ulong id);

		[Get("/statuses/retweets/{id}.json")]
		Task<IEnumerable<Tweet>> Retweets([AliasAs("id")]ulong tweetId);

		[Get("/statuses/retweets_of_me.json")]
		Task<IEnumerable<Tweet>> RetweetsOfMe();

		[Get("/statuses/retweeters/ids.json")]
		Task<IEnumerable<Tweet>> Retweeters();

		//[Get("/statuses/oembed.json")]
		//Task<Tweet> OEmbed();

		//GET statuses/lookup
		//POST statuses/retweet/:id
		//POST statuses/unretweet/:id
		//GET statuses/retweets/:id
		//GET statuses/retweets_of_me
		//GET statuses/retweeters/ids
		
	}
}
