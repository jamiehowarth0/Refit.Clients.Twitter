namespace Refit.Clients.Twitter.Tests
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Refit.Clients.Twitter;
    using Refit.Clients.Twitter.Models;
    using Refit.Clients.Twitter.Models.QueryParams;

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
            this.consumerKey = Environment.GetEnvironmentVariable("Twitter-ConsumerKey");
            this.consumerSecret = Environment.GetEnvironmentVariable("Twitter-ConsumerSecret");
            this.accessToken = Environment.GetEnvironmentVariable("Twitter-AccessToken");
            this.accessTokenSecret = Environment.GetEnvironmentVariable("Twitter-AccessTokenSecret");
            this._client = TwitterClient.Create(this.consumerKey, this.consumerSecret, this.accessToken, this.accessTokenSecret);
            this._account = this._client.Account;
        }

        [Test]
        public async Task Test_AccountSettings_Get()
        {
            var settings = await this._account.Settings();
            Assert.IsNotNull(settings);
        }

        [Test]
        public async Task Test_VerifyCredentials_Get()
        {
            var verifyCredentials = await this._account.VerifyCredentials();
            Assert.IsNotNull(verifyCredentials);
        }

        [Test]
        public async Task Test_ProfileBanner_Get()
        {
            var profileBanners = await this._account.ProfileBanner(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
            Assert.IsNotNull(profileBanners);
        }


        [Test]
        [Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]
        public async Task Test_ProfileBanner_Update()
        {
            var banners = await this._account.ProfileBanner(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
            using (var client = new HttpClient())
            {
                var savedBannerBytes = await client.GetByteArrayAsync(banners.Sizes._1500x500.Url);
                var savedBannerBase64 = Convert.ToBase64String(savedBannerBytes);
                Assert.DoesNotThrowAsync(async () => await this._account.UpdateProfileBanner(null, savedBannerBase64));
            }
        }

        [Test]
        [Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]
        public async Task Test_ProfileBanner_Remove()
        {
            var banners = await this._account.ProfileBanner(new IDOrScreenNameQueryParams() { ScreenName = "benjaminhowarth" });
            var savedBannerBytes = await (new HttpClient()).GetByteArrayAsync(banners.Sizes._1500x500.Url);
            var savedBanner = Convert.ToBase64String(savedBannerBytes);
            Assert.DoesNotThrowAsync(async () => await this._account.RemoveProfileBanner());
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
            // https://twitter.com/search?q=from%3Abenjaminhowarth%20exclude%3Areplies
            // Making the Internet better, faster, & cheaper for your audience, globally. @aspnet consultant & speaker, @ASPInsiders, @LibDems activist. IANAL (yet). He/him
            var settings = new ProfileAccountSettings { Name = "BH Refit test" };
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
            var settings = new ProfileAccountSettings {Name = "Benjamin Howarth" };
            _account.UpdateProfile(settings);
        }
    }
}
