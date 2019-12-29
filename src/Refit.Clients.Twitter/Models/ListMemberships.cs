using System.Collections.Generic;
using Refit.Clients.Twitter.Models.Entities;

namespace Refit.Clients.Twitter.Models
{
    public class ListMemberships : CursoredResultEntity<UserList>
    {
        public IEnumerable<UserList> Lists { get; set; }
    }
}
