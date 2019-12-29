namespace Refit.Clients.Twitter
{
    using System.Threading.Tasks;
    using Refit;
    using Refit.Clients.Twitter.Models.QueryParams;

    [Headers("Authorization: OAuth")]
    public interface IUsers
    {
        [Post("/users/report_spam.json")]
        Task ReportSpam(BlockUserQueryParams blockParameters);

        //GET users/lookup
        //GET users/search
        //GET users/show
        //GET users/suggestions
        //GET users/suggestions/:slug
        //GET users/suggestions/:slug/members
    }
}
