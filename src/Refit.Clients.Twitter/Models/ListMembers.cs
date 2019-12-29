namespace Refit.Clients.Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Refit.Clients.Twitter.Models.Entities;
    public class ListMembers : CursoredResultEntity<User>
{
        public IEnumerable<User> Users { get; set; }
    }
}
