using System;
using System.Collections.Generic;
using System.Text;

namespace Refit.Clients.Twitter.Models.QueryParams
{
    public class ListIDOrSlugCursorQueryParams : ListIDOrSlugQueryParams
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

        /// <summary>
        /// The entities node will not be included when set to false.
        /// </summary>
        [AliasAs("include_entities")]
        public bool IncludeEntities { get; set; }
        /// <summary>
        /// When set to either true, t or 1 statuses will not be included in the returned user objects.
        /// </summary>
        [AliasAs("skip_status")]
        public bool SkipStatus { get; set; }
    }
}
