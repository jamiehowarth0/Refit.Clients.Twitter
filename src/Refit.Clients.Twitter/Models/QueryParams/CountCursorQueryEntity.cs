using System;
using System.Collections.Generic;
using System.Text;

namespace Refit.Clients.Twitter.Models.QueryParams
{
    public class CountCursorQueryParams : IDOrScreenNameQueryParams
    {
        /// <summary>
        /// Specifies the number of results to return per page (see cursor below). The default is 20, with a maximum of 5,000.
        /// </summary>
        [AliasAs("count")]
        public ulong? Count { get; set; }
        /// <summary>
        /// Causes the collection of list members to be broken into "pages" of consistent sizes (specified by the count parameter). If no cursor is provided, a value of -1 will be assumed, which is the first "page."
        /// </summary>
        [AliasAs("cursor")]
        public ulong? Cursor { get; set; }
    }
}
