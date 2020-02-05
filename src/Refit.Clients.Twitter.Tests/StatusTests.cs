using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Refit.Clients.Twitter.Models.QueryParams;

namespace Refit.Clients.Twitter.Tests
{
    [TestFixture]
    public class StatusTests
    {
        private TwitterClient _client;
        private IStatuses _statuses;
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
            this._statuses = this._client.Statuses;
        }

        [Test]
        public async Task Test_Statuses_Get()
        {
            ulong tweetId = 1101833311348031488;
            var tweet = await this._statuses.Get(tweetId);
            Assert.IsNotNull(tweet);
        }

        [Test]
        [Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]
        public async Task Test_Statuses_Post()
        {
            var newTweet = new TweetQueryParams() { Status = "Refit test post" };
            Assert.DoesNotThrowAsync(async () => await this._statuses.Post(newTweet));
        }

        [Test]
        [Explicit("Non-GET REST method, should only be tested against a dummy account ideally")]
        public async Task Test_Statuses_PostWithMedia()
        {
            ulong mediaId = 0;
            using (var file = System.IO.File.OpenRead("test-image.png"))
            {
                var fileBytes = new byte[file.Length];
                file.Read(fileBytes, 0, fileBytes.Length);
                file.Close();
                Assert.DoesNotThrowAsync(async () => { mediaId = await this._client.UploadService.Upload(fileBytes, "image/png"); });
            }

            var newTweet = new TweetQueryParams() { Status = "Refit media test", MediaIDs = mediaId.ToString() };
            Assert.DoesNotThrowAsync(async () => await this._statuses.Post(newTweet));
        }
    }
}
