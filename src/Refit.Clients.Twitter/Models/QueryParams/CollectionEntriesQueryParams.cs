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
            get => this._id.ToString();
            set => this._id = ulong.Parse(value);
        }

        [AliasAs("count")]
        public string Count
        {
            get => this._count.HasValue ? this._count.Value.ToString() : string.Empty;
            set => this._count = int.Parse(value);
        }

        [AliasAs("max_position")]
        public string MaxPosition
        {
            get => this._maxPosition.HasValue ? this._maxPosition.Value.ToString() : string.Empty;
            set => this._maxPosition = int.Parse(value);
        }

        [AliasAs("min_position")]
        public string MinPosition
        {
            get => this._minPosition.HasValue ? this._minPosition.Value.ToString() : string.Empty;
            set => this._minPosition = int.Parse(value);
        }
    }
}
