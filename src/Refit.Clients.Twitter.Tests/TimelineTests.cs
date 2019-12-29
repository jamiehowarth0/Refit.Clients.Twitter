namespace Refit.Clients.Twitter.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Refit.Clients.Twitter;
    using Refit.Clients.Twitter.Models.QueryParams;

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
            this.consumerKey = Environment.GetEnvironmentVariable("Twitter-ConsumerKey");
            this.consumerSecret = Environment.GetEnvironmentVariable("Twitter-ConsumerSecret");
            this.accessToken = Environment.GetEnvironmentVariable("Twitter-AccessToken");
            this.accessTokenSecret = Environment.GetEnvironmentVariable("Twitter-AccessTokenSecret");
            this._client = TwitterClient.Create(this.consumerKey, this.consumerSecret, this.accessToken, this.accessTokenSecret);
            this._timelines = this._client.Timelines;
        }

        [Test]
        public async Task Test_Home_DefaultOptions()
        {
            var tweets = await this._timelines.Home(UserTimelineQueryParams.Default);
            Assert.That(tweets.Any());
        }

        [Test]
        public async Task Test_User_DefaultOptions()
        {
            var tweets = await this._timelines.User(UserTimelineQueryParams.Default);
            Assert.That(tweets.Any());
        }

        [Test]
        public async Task Test_Mentions_DefaultOptions()
        {
            var tweets = await this._timelines.Mentions(UserTimelineQueryParams.Default);
            Assert.That(tweets.Any());
        }

        [Test]
        public async Task Test_Home_CustomOptions()
        {
            var tweets = await this._timelines.Home(new UserTimelineQueryParams() { IncludeEntities = false.ToString(), Page = "2" });
            Assert.IsNotNull(tweets);
            Assert.That(tweets.Any());
        }

        [Test]
        public async Task Test_User_CustomOptions()
        {
            var tweets = await this._timelines.User(new UserTimelineQueryParams() { IncludeEntities = false.ToString(), Page = "2" });
            Assert.IsNotNull(tweets);
            Assert.That(tweets.Any());
        }

        [Test]
        public async Task Test_Mentions_CustomOptions()
        {
            var tweets = await this._timelines.Mentions(new UserTimelineQueryParams() { IncludeEntities = false.ToString(), Page = "2" });
            Assert.IsNotNull(tweets);
            Assert.That(tweets.Any());
        }
    }
}
