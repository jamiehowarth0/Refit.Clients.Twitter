namespace Refit.Clients.Twitter.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Refit.Clients.Twitter;
    using Refit.Clients.Twitter.Models.QueryParams;

    [TestFixture]
    public class ListTests
    {
        private TwitterClient _client;
        private ILists _lists;
        private string consumerKey;
        private string consumerSecret;
        private string accessToken;
        private string accessTokenSecret;

        [SetUp]
        public void Setup()
        {
            this.consumerKey = Environment.GetEnvironmentVariable("Twitter-ConsumerKey");
            this.consumerSecret = Environment.GetEnvironmentVariable("Twitter-ConsumerSecret");
            this.accessToken = Environment.GetEnvironmentVariable("Twitter-AccessToken");
            this.accessTokenSecret = Environment.GetEnvironmentVariable("Twitter-AccessTokenSecret");
            this._client = TwitterClient.Create(this.consumerKey, this.consumerSecret, this.accessToken, this.accessTokenSecret);
            this._lists = this._client.Lists;
        }

        [Test]
        public async Task Test_Lists_Get()
        {
            var lists = await this._lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
            Assert.IsNotNull(lists);
            Assert.AreEqual(12, lists.Count());
        }

        [Test]
        public async Task Test_Lists_Show()
        {
            var lists = await this._lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
            var singleList = lists.First(list => list.Mode == "public" && list.User.ScreenName == "benjaminhowarth");
            var showLists = await this._lists.ShowList(new ListIDOrSlugQueryParams() { ListID = singleList.ID });
            Assert.IsNotNull(showLists);
            Assert.AreEqual(singleList.ID, showLists.ID);
        }

        [Test]
        public async Task Test_ListMembers_Get()
        {
            var lists = await this._lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
            var singleList = lists.OrderBy(list => list.Name).First(list => list.Mode == "public" && list.User.ScreenName == "benjaminhowarth");
            var listMembers = await this._lists.GetMembers(new ListMembersQueryParams() { ListID = singleList.ID, Count = 100 });
            Assert.IsNotNull(listMembers);
            Assert.IsNotEmpty(listMembers.Users);
            Assert.AreEqual(22, listMembers.Users.Count());
        }

        [Test]
        public async Task Test_ListMembers_Show()
        {
            var lists = await this._lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
            var singleList = lists.OrderBy(list => list.Name).First(list => list.Mode == "public" && list.User.ScreenName == "benjaminhowarth");
            var listMember = await this._lists.ShowMember(new ListMemberQueryParams() { ListID = singleList.ID, ScreenName = "cmwlondon" });
            Assert.IsNotNull(listMember);
        }

        [Test]
        public async Task Test_ListMemberships_Get()
        {
            var memberships = await this._lists.GetMemberships(new ListMembershipQueryParams() { ScreenName = "benjaminhowarth" });
            Assert.IsNotNull(memberships);
            Assert.IsNotEmpty(memberships.Lists);
        }

        [Test]
        public async Task Test_ListOwnerships_Get()
        {
            var memberships = await this._lists.GetOwnerships(new ListMembershipQueryParams() { ScreenName = "benjaminhowarth" });
            Assert.IsNotNull(memberships);
            Assert.IsNotEmpty(memberships.Lists);
        }

        [Test]
        public async Task Test_ListStatuses_Get()
        {
            var statuses = await this._lists.GetStatuses();
            Assert.IsNotEmpty(statuses);
        }

        [Test]
        public async Task Test_ListSubscribers_Get()
        {
            Assert.Fail();
            var memberships = await this._lists.GetSubscribers();
            Assert.IsNotNull(memberships);
            // Assert.IsNotEmpty(memberships.Lists);
        }

        [Test]
        public async Task Test_ListSubscribers_Show()
        {
            Assert.Fail();
        }

        [Test]
        public async Task Test_ListSubscriptions_Get()
        {
            var subscriptions = await this._lists.GetSubscriptions(new CountCursorQueryParams() { ScreenName = "benjaminhowarth" });
            Assert.IsNotNull(subscriptions);
            Assert.IsNotEmpty(subscriptions.Lists);
        }

        [Test]
        [Explicit]
        public async Task Test_List_Create()
        {
            // var newList = _lists.CreateList();
            Assert.Fail();
        }

        [Test]
        [Explicit]
        public async Task Test_List_Update()
        {
            Assert.Fail();
        }

        [Test]
        [Explicit]
        public async Task Test_List_Delete()
        {
            Assert.Fail();
        }

        [Test]
        [Explicit]
        public async Task Test_ListMember_Create()
        {
            Assert.Fail();
        }

        [Test]
        [Explicit]
        public async Task Test_ListMember_CreateAll()
        {
            Assert.Fail();
        }

        [Test]
        [Explicit]
        public async Task Test_ListMember_Delete()
        {
            Assert.Fail();
        }

        [Test]
        [Explicit]
        public async Task Test_ListMember_DeleteAll()
        {
            Assert.Fail();
        }

        [Test]
        [Explicit]
        public async Task Test_ListSubscriber_Create()
        {
            Assert.Fail();
        }

        [Test]
        [Explicit]
        public async Task Test_ListSubscriber_Delete()
        {
            Assert.Fail();
        }

    }
}
