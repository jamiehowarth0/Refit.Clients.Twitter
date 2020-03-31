// <copyright file="TimelineTests.cs" company="Benjamin Howarth &amp; contributors">
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
	public class TimelineTests
	{
		private TwitterClient _client;
		private ITimelines _timelines;
		private string consumerKey;
		private string consumerSecret;
		private string accessToken;
		private string accessTokenSecret;

		[SetUp]
		public void Setup()
		{
			consumerKey = Environment.GetEnvironmentVariable("Twitter-ConsumerKey");
			consumerSecret = Environment.GetEnvironmentVariable("Twitter-ConsumerSecret");
			accessToken = Environment.GetEnvironmentVariable("Twitter-AccessToken");
			accessTokenSecret = Environment.GetEnvironmentVariable("Twitter-AccessTokenSecret");
			_client = TwitterClient.Create(consumerKey, consumerSecret, accessToken, accessTokenSecret);
			_timelines = _client.Timelines;
		}

		[Test]
		public async Task Test_Home_DefaultOptions()
		{
			var tweets = await _timelines.Home(UserTimelineQueryParams.Default);
			Assert.That(tweets.Any());
		}

		[Test]
		public async Task Test_User_DefaultOptions()
		{
			var tweets = await _timelines.User(UserTimelineQueryParams.Default);
			Assert.That(tweets.Any());
		}

		[Test]
		public async Task Test_Mentions_DefaultOptions()
		{
			var tweets = await _timelines.Mentions(UserTimelineQueryParams.Default);
			Assert.That(tweets.Any());
		}

		[Test]
		public async Task Test_Home_CustomOptions()
		{
			var tweets = await _timelines.Home(new UserTimelineQueryParams() { IncludeEntities = false.ToString(), Page = "2" });
			Assert.IsNotNull(tweets);
			Assert.That(tweets.Any());
		}

		[Test]
		public async Task Test_User_CustomOptions()
		{
			var tweets = await _timelines.User(new UserTimelineQueryParams() { IncludeEntities = false.ToString(), Page = "2" })
				.ConfigureAwait(false);
			Assert.IsNotNull(tweets);
			Assert.That(tweets.Any());
		}

		[Test]
		public async Task Test_Mentions_CustomOptions()
		{
			var tweets = await _timelines.Mentions(new UserTimelineQueryParams() { IncludeEntities = false.ToString(), Page = "2" })
				.ConfigureAwait(false);
			Assert.IsNotNull(tweets);
			Assert.That(tweets.Any());
		}
	}
}
