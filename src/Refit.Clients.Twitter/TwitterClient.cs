// <copyright file="TwitterClient.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using Refit.Clients.Twitter.Extensions;

namespace Refit.Clients.Twitter
{
	public class TwitterClient
	{
		internal static string NowAsString = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);

		private readonly RefitSettings _settings;

		private readonly string ConsumerKey;
		private readonly string AccessToken;
		// private readonly Dictionary<string, string> RequestParameters;
		private readonly string SigningKey;

		public static readonly string TwitterTimeFormat = "ddd MMM dd HH:mm:ss zzzz yyyy";
		public static readonly string TwitterEndpoint = "https://api.twitter.com/1.1";

		private TwitterClient(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
		{
			ConsumerKey = consumerKey;
			AccessToken = accessToken;
			SigningKey = $"{consumerSecret.UrlEncode()}&{accessTokenSecret.UrlEncode()}";
			_settings = new RefitSettings()
			{
				HttpMessageHandlerFactory = () => new OAuthHttpClientHandler(GetToken, null),

				// AuthorizationHeaderValueGetter = () => { return Task.FromResult(GetToken()); },
				ContentSerializer = new CompressedJsonContentSerializer(new JsonSerializerSettings()
				{
					DateFormatString = TwitterTimeFormat,
					ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() },
				}),
			};

			UploadService = new StreamedMediaUploadService(consumerKey, consumerSecret, accessToken, accessTokenSecret);
		}

		public IAccount Account => RestService.For<IAccount>(TwitterEndpoint, _settings);

		public ICollections Collections => RestService.For<ICollections>(TwitterEndpoint, _settings);

		public IFriendships Friendships => RestService.For<IFriendships>(TwitterEndpoint, _settings);

		public ILists Lists => RestService.For<ILists>(TwitterEndpoint, _settings);

		public IStatuses Statuses => RestService.For<IStatuses>(TwitterEndpoint, _settings);

		public ITimelines Timelines => RestService.For<ITimelines>(TwitterEndpoint, _settings);

		public ITrends Trends => RestService.For<ITrends>(TwitterEndpoint, _settings);

		public IUsers Users => RestService.For<IUsers>(TwitterEndpoint, _settings);

		public StreamedMediaUploadService UploadService { get; set; }

		public static TwitterClient Create(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
		{
			return new TwitterClient(consumerKey, consumerSecret, accessToken, accessTokenSecret);
		}

		private Task<string> GetToken(HttpRequestMessage message)
		{
			var RequestParams = new Dictionary<string, string>()
			{
				{ "oauth_consumer_key", ConsumerKey },
				{ "oauth_signature_method", "HMAC-SHA1" },
				{ "oauth_token", AccessToken },
				{ "oauth_version", "1.0" },
			};

			return message.GetToken(ConsumerKey, AccessToken, SigningKey, RequestParams);
		}
	}
}
