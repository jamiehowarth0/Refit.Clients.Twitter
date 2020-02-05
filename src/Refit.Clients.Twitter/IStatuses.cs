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

		//POST statuses/update
		//POST statuses/destroy/:id
		//GET statuses/show/:id
		//GET statuses/oembed

		//GET statuses/lookup
		//POST statuses/retweet/:id
		//POST statuses/unretweet/:id
		//GET statuses/retweets/:id
		//GET statuses/retweets_of_me
		//GET statuses/retweeters/ids
	}
}