namespace Refit.Clients.Twitter.Models
{
    using System.Collections.Generic;
    using Refit.Clients.Twitter.Models.Entities;
    public class ListMembers : CursoredResultEntity<User>
{
        public IEnumerable<User> Users { get; set; }
    }
}
