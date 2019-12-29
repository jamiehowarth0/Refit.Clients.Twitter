using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Refit;

namespace Refit.Clients.Twitter
{
    [Headers("Authorization: OAuth")]
    public interface ITrends
    {
        [Get("/trends/available.json")]
        IEnumerable<WoeID> Available();

        [Get("/trends/closest.json")]
        IEnumerable<WoeID> Closest([Query] LocationQueryParams location);
    }
}
