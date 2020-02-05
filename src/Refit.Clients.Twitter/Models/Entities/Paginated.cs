using System.Collections.Generic;

namespace Refit.Clients.Twitter.Models.Entities
{
    public class Paginated<T>
		where T : class
	{
		public ulong NextCursor { get; set; }

		public string NextCursorStr { get; set; }

		public ulong PreviousCursor { get; set; }

		public string PreviousCursorStr { get; set; }

		public IEnumerable<T> Items { get; set; }
	}
}
