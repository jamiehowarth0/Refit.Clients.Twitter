namespace Refit.Clients.Twitter
{
    using System.Threading.Tasks;
    using Refit;
    using Refit.Clients.Twitter.Models.QueryParams;

    [Headers("Authorization: OAuth")]
    public interface ICollections
    {
        [Get("/collections/entries.json")]
        Task Entries([Query]CollectionEntriesQueryParams queryParams);

        [Get("/collections/show.json")]
        Task Show([Query]object queryParams);

        [Get("/collections/list.json")]
        Task List([Query]object queryParams);

        [Post("/collections/create.json")]
        Task Create([Query] object queryParams);

        [Post("/collections/update.json")]
        Task Update([Query] object queryParams);

        [Post("/collections/destroy.json")]
        Task Destroy([Query] object queryParams);

        //GET collections/list
        //GET collections/show
        //POST collections/create
        //POST collections/destroy
        //POST collections/update
        //POST collections/entries/add
        //POST collections/entries/curate
        //POST collections/entries/move
        //POST collections/entries/remove
    }
}
