using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Refit.Clients.Twitter
{

	[Headers("Authorization: OAuth")]
	public interface IFriendships
	{
		[Get("/friends/ids.json")]
		public async Task GetByIds();

		[Get("/friends/list.json")]
		public async Task List();

		[Get("/friendships/incoming.json")]
		public async Task Incoming();

		[Get("/friendships/outgoing.json")]
		public async Task Outgoing();

		[Get("/friendships/lookup.json")]
		public async Task Lookup();

		[Get("/friendships/show.json")]
		public async Task Show();

		[Get("/friendships/no_retweets/ids.json")]
		public async Task<IEnumerable<int>> NoRetweets();

		[Post("/friendships/create.json")]
		public async Task Create();

		[Post("/friendships/destroy.json")]
		public async Task Destroy();

		[Post("/friendships/update.json")]
		public async Task Update();

		//GET friendships/no_retweets/ids
		//GET friendships/show
		
		//GET followers/ids
		//GET followers/list

	}
}
