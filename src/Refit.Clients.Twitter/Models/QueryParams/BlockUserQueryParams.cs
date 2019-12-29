namespace Refit.Clients.Twitter.Models.QueryParams
{
    using System;

    public class BlockUserQueryParams : IDOrScreenNameQueryParams
    {
        private bool? _performBlock;

        [AliasAs("perform_block")]
        public string PerformBlock
        {
            get => this._performBlock.HasValue ? this._performBlock.Value.ToString().ToLowerInvariant() : Boolean.TrueString.ToLowerInvariant();
            set => this._performBlock = bool.Parse(value);
        }


    }
}
