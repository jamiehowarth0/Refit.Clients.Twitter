using System.Runtime.Remoting;

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
		private string listName;
		private string listDescription;

		[SetUp]
		public void Setup()
		{
			this.consumerKey = Environment.GetEnvironmentVariable("Twitter-ConsumerKey");
			this.consumerSecret = Environment.GetEnvironmentVariable("Twitter-ConsumerSecret");
			this.accessToken = Environment.GetEnvironmentVariable("Twitter-AccessToken");
			this.accessTokenSecret = Environment.GetEnvironmentVariable("Twitter-AccessTokenSecret");
			this.listName = "Refit test list";
			this.listDescription = "Refit test list description";
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
			// var statuses = await this._lists.GetStatuses();
			// Assert.IsNotEmpty(statuses);
			Assert.Fail();
		}

		[Test]
		public async Task Test_ListSubscribers_Get()
		{
			var list = (await this._lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" })).First();
			var subscribers = await this._lists.GetSubscribers(new ListIDOrSlugCursorQueryParams() { ListID = list.ID });
			Assert.IsNotNull(subscribers);
			Assert.IsNotEmpty(subscribers.Users);
		}

		[Test]
		public async Task Test_ListSubscribers_Show()
		{
			Assert.Fail();

			//var list = (await this._lists.GetLists(new IDOrScreenNameQueryParams() {ScreenName = "benjaminhowarth"})).First();
			//var subscribers = await this._lists.ShowSubscribers( new ListIDOrSlugCursorQueryParams() { ListID = list.ID });
			//Assert.IsNotNull(subscribers);
			//Assert.IsNotEmpty(subscribers.Users);
		}

		[Test]
		public async Task Test_ListSubscriptions_Get()
		{
			var subscriptions = await this._lists.GetSubscriptions(new CountCursorQueryParams() { ScreenName = "benjaminhowarth" });
			Assert.IsNotNull(subscriptions);
			Assert.IsNotEmpty(subscriptions.Lists);
		}

		[Test]
		[Category("List operations")]
		[Order(1)]
		public async Task Test_List_Create()
		{
			var newList = await _lists.CreateList(new ListCreateQueryParams() { Name = this.listName });
			Assert.IsNotNull(newList);
		}

		[Test]
		[Category("List operations")]
		[Order(2)]
		public async Task Test_List_Update()
		{
			var list = (await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" }))
				.FirstOrDefault(n => n.Name == this.listName);
			var updatedList = await _lists.UpdateList(new UpdateListQueryParams() { Description = this.listDescription, ID = list.ID });
			Assert.IsNotNull(updatedList);
			Assert.AreEqual(this.listDescription, updatedList.Description);
		}

		[Test]
		[Category("List operations")]
		[Order(3)]
		public async Task Test_List_Delete()
		{
			var list = (await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" }))
						.FirstOrDefault(n => n.Name == this.listName);
			var deleteList = await _lists.DeleteList(new ListIDOrSlugQueryParams() { ListID = list.ID });
			Assert.IsNotNull(deleteList);
			Assert.AreEqual(list.ID, deleteList.ID);
		}

		[Test]
		public async Task Test_ListMember_Create()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_ListMember_CreateAll()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_ListMember_Delete()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_ListMember_DeleteAll()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_ListSubscriber_Create()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_ListSubscriber_Delete()
		{
			Assert.Fail();
		}

	}
}
