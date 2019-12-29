namespace Refit.Clients.Twitter
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Refit;
    using Refit.Clients.Twitter.Models;
    using Refit.Clients.Twitter.Models.QueryParams;

    [Headers("Authorization: OAuth")]
    public interface ILists
    {
        [Get("/lists/list.json")]
        Task<IEnumerable<UserList>> GetLists([Query]IDOrScreenNameQueryParams queryParams);

        [Get("/lists/members.json")]
        Task<ListMembers> GetMembers([Query]ListMembersQueryParams queryParams);

        [Get("/lists/members/show.json")]
        Task<User> ShowMember([Query]ListMemberQueryParams queryParams);

        [Get("/lists/memberships.json")]
        Task<ListMemberships> GetMemberships([Query]ListMembershipQueryParams queryParams);

        [Get("/lists/ownerships.json")]
        Task<ListMemberships> GetOwnerships([Query]ListMembershipQueryParams queryParams);

        [Get("/lists/show.json")]
        Task<UserList> ShowList([Query]ListIDOrSlugQueryParams queryParams);

        [Get("/lists/statuses.json")]
        Task<IEnumerable<Tweet>> GetStatuses([Query]ListStatusQueryParams queryParams);

        [Get("/lists/subscribers.json")]
        Task<ListMembers> GetSubscribers();

        [Get("/lists/subscribers/show.json")]
        Task<User> ShowSubscribers();

        [Get("/lists/subscriptions.json")]
        Task<ListMemberships> GetSubscriptions([Query]CountCursorQueryParams queryParams);

        [Post("/lists/create.json")]
        Task<UserList> CreateList([Query]ListCreateQueryParams createParams);

        [Post("/lists/destroy.json")]
        Task<UserList> DeleteList([Query]ListIDOrSlugQueryParams destroyParams);

        [Post("/lists/members/create.json")]
        Task CreateListMember();

        [Post("/lists/members/create_all.json")]
        Task CreateAllListMembers();

        [Post("/lists/members/destroy.json")]
        Task DeleteListMember();

        [Post("/lists/members/destroy_all.json")]
        Task DeleteAllListMembers();

        [Post("/lists/subscribers/create.json")]
        Task CreateListSubscriber();

        [Post("/lists/subscribers/destroy.json")]
        Task DeleteListSubscriber();

        [Post("/lists/update.json")]
        Task<UserList> UpdateList([Query]UserList list);
    }

    public class ListStatusQueryParams
    {
    }
}
