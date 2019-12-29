namespace Refit.Clients.Twitter
{
    using System.Collections.Generic;
    using Refit.Clients.Twitter.Models.Entities;

    [Headers("Authorization: OAuth")]
    public interface ITrends
    {
        [Get("/trends/available.json")]
        IEnumerable<WoeID> Available();

        [Get("/trends/closest.json")]
        IEnumerable<WoeID> Closest([Query] LocationQueryParams location);
    }
}
