// <copyright file="ListTests.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Refit.Clients.Twitter.Models.QueryParams;

namespace Refit.Clients.Twitter.Tests
{
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
            var config = LocalSecretConfiguration.GetConfig();
            consumerKey = config["Twitter-ConsumerKey"];
            consumerSecret = config["Twitter-ConsumerSecret"];
            accessToken = config["Twitter-AccessToken"];
            accessTokenSecret = config["Twitter-AccessTokenSecret"];
			listName = "Refit test list";
			listDescription = "Refit test list description";
			_client = TwitterClient.Create(consumerKey, consumerSecret, accessToken, accessTokenSecret);
			_lists = _client.Lists;
		}

		[Test]
		public async Task Test_Lists_Get()
		{
			var lists = await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
			Assert.IsNotNull(lists);
			Assert.AreEqual(12, lists.Count());
		}

		[Test]
		public async Task Test_Lists_Show()
		{
			var lists = await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
			var singleList = lists.First(list => list.Mode == "public" && list.User.ScreenName == "benjaminhowarth");
			var showLists = await _lists.ShowList(new ListIDOrSlugQueryParams() { ListID = singleList.ID });
			Assert.IsNotNull(showLists);
			Assert.AreEqual(singleList.ID, showLists.ID);
		}

		[Test]
		public async Task Test_ListMembers_Get()
		{
			var lists = await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
			var singleList = lists.OrderBy(list => list.Name).First(list => list.Mode == "public" && list.User.ScreenName == "benjaminhowarth");
			var listMembers = await _lists.GetMembers(new ListMembersQueryParams() { ListID = singleList.ID, Count = 100 });
			Assert.IsNotNull(listMembers);
			Assert.IsNotEmpty(listMembers.Users);
			Assert.AreEqual(22, listMembers.Users.Count());
		}

		[Test]
		public async Task Test_ListMembers_Show()
		{
			var lists = await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
			var singleList = lists.OrderBy(list => list.Name).First(list => list.Mode == "public" && list.User.ScreenName == "benjaminhowarth");
			var listMember = await _lists.ShowMember(new ListMemberQueryParams() { ListID = singleList.ID, ScreenName = "cmwlondon" });
			Assert.IsNotNull(listMember);
		}

		[Test]
		public async Task Test_ListMemberships_Get()
		{
			var memberships = await _lists.GetMemberships(new ListMembershipQueryParams() { ScreenName = "benjaminhowarth" });
			Assert.IsNotNull(memberships);
			Assert.IsNotEmpty(memberships.Lists);
		}

		[Test]
		public async Task Test_ListOwnerships_Get()
		{
			var memberships = await _lists.GetOwnerships(new ListMembershipQueryParams() { ScreenName = "benjaminhowarth" });
			Assert.IsNotNull(memberships);
			Assert.IsNotEmpty(memberships.Lists);
            Assert.AreEqual(10, memberships.Lists.Count());
		}

		[Test]
		public async Task Test_ListStatuses_Get()
		{
			// var statuses = await _lists.GetStatuses();
			// Assert.IsNotEmpty(statuses);
			Assert.Fail();
		}

		[Test]
		public async Task Test_ListSubscribers_Get()
		{
			var list = (await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" })).First();
			var subscribers = await _lists.GetSubscribers(new ListIDOrSlugCursorQueryParams() { ListID = list.ID });
			Assert.IsNotNull(subscribers);
			Assert.IsNotEmpty(subscribers.Users);
		}

		[Test]
		public async Task Test_ListSubscribers_Show()
		{
			Assert.Fail();

			//var list = (await _lists.GetLists(new IDOrScreenNameQueryParams() {ScreenName = "benjaminhowarth"})).First();
			//var subscribers = await _lists.ShowSubscribers( new ListIDOrSlugCursorQueryParams() { ListID = list.ID });
			//Assert.IsNotNull(subscribers);
			//Assert.IsNotEmpty(subscribers.Users);
		}

		[Test]
		public async Task Test_ListSubscriptions_Get()
		{
			var subscriptions = await _lists.GetSubscriptions(new CountCursorQueryParams() { ScreenName = "benjaminhowarth" });
			Assert.IsNotNull(subscriptions);
			Assert.IsNotEmpty(subscriptions.Lists);
            Assert.AreEqual(2, subscriptions.Lists.Count());
		}

		[Test]
		[Category("List operations")]
		[Order(1)]
		public async Task Test_List_Create()
		{
			var newList = await _lists.CreateList(new ListCreateQueryParams() { Name = listName });
			Assert.IsNotNull(newList);
		}

		[Test]
		[Category("List operations")]
		[Order(2)]
		public async Task Test_List_Update()
		{
			var list = (await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" }))
				.FirstOrDefault(n => n.Name == listName);
			var updatedList = await _lists.UpdateList(new UpdateListQueryParams() { Description = listDescription, ID = list.ID });
			Assert.IsNotNull(updatedList);
			Assert.AreEqual(listDescription, updatedList.Description);
		}

		[Test]
		[Category("List operations")]
		[Order(3)]
		public async Task Test_List_Delete()
		{
			var list = (await _lists.GetLists(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" }))
						.FirstOrDefault(n => n.Name == listName);
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
            // Need to do this to a public list that we own
			Assert.Fail();
		}

		[Test]
		public async Task Test_ListSubscriber_Delete()
		{
			Assert.Fail();
		}

	}
}
