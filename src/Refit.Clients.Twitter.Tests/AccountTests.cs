// <copyright file="AccountTests.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Refit.Clients.Twitter;
using Refit.Clients.Twitter.Models;
using Refit.Clients.Twitter.Models.QueryParams;

namespace Refit.Clients.Twitter.Tests
{
	[TestFixture]
	public class AccountTests
	{
		private TwitterClient _client;
		private IAccount _account;
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
			_account = _client.Account;
		}

		[Test]
		public async Task Test_AccountSettings_Get()
		{
			var settings = await _account.Settings().ConfigureAwait(false);
			Assert.IsNotNull(settings);
		}

		[Test]
		public async Task Test_VerifyCredentials_Get()
		{
			var verifyCredentials = await _account.VerifyCredentials().ConfigureAwait(false);
			Assert.IsNotNull(verifyCredentials);
		}

		[Test]
		public async Task Test_ProfileBanner_Get()
		{
			var profileBanners = await _account.ProfileBanner(new IDOrScreenNameQueryParams() { ScreenName = "Politiplay" })
				.ConfigureAwait(false);
			Assert.IsNotNull(profileBanners);
		}

		[Test]
		[Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]
		public async Task Test_ProfileBanner_Update()
		{
			var banners = await _account.ProfileBanner(new IDOrScreenNameQueryParams() { ScreenName = "Politiplay" })
				.ConfigureAwait(false);
			using (var client = new HttpClient())
			{
				var savedBannerBytes = await client.GetByteArrayAsync(banners.Sizes._1500x500.Url).ConfigureAwait(false);
				var savedBannerBase64 = Convert.ToBase64String(savedBannerBytes);
				Assert.DoesNotThrowAsync(async () => await _account.UpdateProfileBanner(null, savedBannerBase64)
					.ConfigureAwait(false));
			}
		}

		[Test]
		[Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]
		public async Task Test_ProfileBanner_Remove()
		{
			var banners = await _account.ProfileBanner(new IDOrScreenNameQueryParams() { ScreenName = "Politiplay" })
				.ConfigureAwait(false);
			var savedBannerBytes = await (new HttpClient()).GetByteArrayAsync(banners.Sizes._1500x500.Url)
				.ConfigureAwait(false);
			var savedBanner = Convert.ToBase64String(savedBannerBytes);
			Assert.DoesNotThrowAsync(async () => await _account.RemoveProfileBanner());
		}

		[Test]
		[Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]

		public async Task Test_Settings_Update()
		{
			Assert.Fail();
		}

		[Test]
		[Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]
		public async Task Test_Profile_Update()
		{
			var settings = new ProfileAccountSettings { Name = "Politiplay Refit test" };
			Assert.DoesNotThrowAsync(async () => await _account.UpdateProfile(settings));
		}

		[Test]
		[Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]
		public async Task Test_ProfileImage_Update()
		{
			Assert.Fail();
		}

		[TearDown]
		public void Teardown()
		{
			var settings = new ProfileAccountSettings { Name = "Benjamin Howarth" };
			_account.UpdateProfile(settings);
		}
	}
}
