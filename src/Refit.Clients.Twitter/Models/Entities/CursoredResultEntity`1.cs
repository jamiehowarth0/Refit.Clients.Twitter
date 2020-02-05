namespace Refit.Clients.Twitter.Models.Entities
{
	public abstract class CursoredResultEntity<T>
		where T : class
	{
		public ulong NextCursor { get; set; }
		public string NextCursorStr { get; set; }
		public ulong PreviousCursor { get; set; }
		public string PreviousCursorStr { get; set; }
		public ulong? TotalCount { get; set; }
	}
}
