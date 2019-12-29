namespace Refit.Clients.Twitter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Refit;
    using Refit.Clients.Twitter.Extensions;
    using Refit.Clients.Twitter.Helpers;

    public class TwitterClient
    {
        private readonly RefitSettings _settings;

        private readonly string ConsumerKey;
        private readonly string AccessToken;
        // private readonly Dictionary<string, string> RequestParameters;
        private readonly string SigningKey;

        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static readonly string TwitterTimeFormat = "ddd MMM dd HH:mm:ss zzzz yyyy";
        public static readonly string TwitterEndpoint = "https://api.twitter.com/1.1";

        internal static string NowAsString = Convert.ToInt64(DateTime.UtcNow.Subtract(UnixEpoch).TotalSeconds, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        internal static readonly string Nonce = Guid.NewGuid().ToString("N");

        private TwitterClient(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            this.ConsumerKey = consumerKey;
            this.AccessToken = accessToken;
            this.SigningKey = $"{UriExtensions.UrlEncode(consumerSecret)}&{UriExtensions.UrlEncode(accessTokenSecret)}";
            this._settings = new RefitSettings()
            {
                HttpMessageHandlerFactory = () => new OAuthHttpClientHandler(this.GetToken, null),
                // AuthorizationHeaderValueGetter = () => { return Task.FromResult(GetToken()); },
                ContentSerializer = new CompressedJsonContentSerializer(new JsonSerializerSettings()
                {
                    DateFormatString = TwitterTimeFormat,
                    ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() },
                }),
            };

            this.UploadService = new StreamedMediaUploadService(consumerKey, consumerSecret, accessToken, accessTokenSecret);
        }

        public static TwitterClient Create(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            return new TwitterClient(consumerKey, consumerSecret, accessToken, accessTokenSecret);
        }

        public IAccount Account { get => RestService.For<IAccount>(TwitterEndpoint, this._settings); }

        public ICollections Collections { get => RestService.For<ICollections>(TwitterEndpoint, this._settings); }

        public IFriendships Friendships { get => RestService.For<IFriendships>(TwitterEndpoint, this._settings); }

        public ILists Lists { get => RestService.For<ILists>(TwitterEndpoint, this._settings); }

        public IStatuses Statuses { get => RestService.For<IStatuses>(TwitterEndpoint, this._settings); }

        public ITimelines Timelines { get => RestService.For<ITimelines>(TwitterEndpoint, this._settings); }

        public ITrends Trends { get => RestService.For<ITrends>(TwitterEndpoint, this._settings); }

        public IUsers Users { get => RestService.For<IUsers>(TwitterEndpoint, this._settings); }

        public StreamedMediaUploadService UploadService { get; set; }

        private Task<string> GetToken(HttpRequestMessage message)
        {
            var RequestParams = new Dictionary<string, string>()
            {
                {"oauth_consumer_key", this.ConsumerKey},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_token", this.AccessToken},
                {"oauth_version", "1.0"}
            };

            return message.GetToken(this.ConsumerKey, this.AccessToken, this.SigningKey, RequestParams);
        }
    }
}
