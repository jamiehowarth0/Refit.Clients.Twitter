using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Refit.Clients.Twitter.Models;
using Refit.Clients.Twitter.Models.QueryParams;

namespace Refit.Clients.Twitter
{
	[Headers("Authorization: OAuth")]
	public interface ITimelines
	{
		[Get("/statuses/user_timeline.json")]
		Task<IEnumerable<Tweet>> User([Query]UserTimelineQueryParams myParams);

		[Get("/statuses/home_timeline.json")]
		Task<IEnumerable<Tweet>> Home([Query]UserTimelineQueryParams myParams);

		[Get("/statuses/mentions_timeline.json")]
		Task<IEnumerable<Tweet>> Mentions([Query]UserTimelineQueryParams myParams);
	}
}
