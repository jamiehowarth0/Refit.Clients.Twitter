using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Refit.Clients.Twitter.Tests
{
	[TestFixture]
	public class CollectionsTests
	{
		private TwitterClient _client;
		private ICollections _collections;
		private string consumerKey;
		private string consumerSecret;
		private string accessToken;
		private string accessTokenSecret;

		[SetUp]
		public void Setup()
		{
            consumerKey = Environment.GetEnvironmentVariable(Constants.ConsumerKey);
            consumerSecret = Environment.GetEnvironmentVariable(Constants.ConsumerSecret);
            accessToken = Environment.GetEnvironmentVariable(Constants.AccessToken);
            accessTokenSecret = Environment.GetEnvironmentVariable(Constants.AccessTokenSecret);
			_client = TwitterClient.Create(consumerKey, consumerSecret, accessToken, accessTokenSecret);
			_collections = _client.Collections;
		}

		[Test]
		public async Task Test_Collections_GetEntries()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_List()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_Show()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_Create()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_Update()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_Destroy()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_AddEntry()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_CurateEntries()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_MoveEntry()
		{
			Assert.Fail();
		}

		[Test]
		public async Task Test_Collections_RemoveEntry()
		{
			Assert.Fail();
		}
	}
}
