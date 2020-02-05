namespace Refit.Clients.Twitter.Models.QueryParams
{
	public class CollectionEntriesQueryParams
	{
		private ulong _id;
		private int? _count;
		private int? _maxPosition;
		private int? _minPosition;

		[AliasAs("id")]
		public string ID
		{
			get => _id.ToString();
			set => _id = ulong.Parse(value);
		}

		[AliasAs("count")]
		public string Count
		{
			get => _count.HasValue ? _count.Value.ToString() : string.Empty;
			set => _count = int.Parse(value);
		}

		[AliasAs("max_position")]
		public string MaxPosition
		{
			get => _maxPosition.HasValue ? _maxPosition.Value.ToString() : string.Empty;
			set => _maxPosition = int.Parse(value);
		}

		[AliasAs("min_position")]
		public string MinPosition
		{
			get => _minPosition.HasValue ? _minPosition.Value.ToString() : string.Empty;
			set => _minPosition = int.Parse(value);
		}
	}
}
