// <copyright file="StreamedMediaUploadService.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit.Clients.Twitter.Models;

namespace Refit.Clients.Twitter
{
	public class StreamedMediaUploadService
	{
		private string _consumerKey;
		private string _consumerSecret;
		private string _accessToken;
		private string _accessTokenSecret;
		private readonly string _endpoint = "https://upload.twitter.com/1.1/media/upload.json";

		internal StreamedMediaUploadService(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
		{
			_consumerKey = consumerKey;
			_consumerSecret = consumerSecret;
			_accessToken = accessToken;
			_accessTokenSecret = accessTokenSecret;
		}

		public async Task<ulong> Upload(byte[] content, int chunkAt, string contentType, string mediaCategory = "", string[] additionalUsers = null)
		{
			using (var client = new HttpClient())
			{
				var mediaInit = await Init(client, content.Length, contentType, mediaCategory, additionalUsers);

			}
			throw new NotImplementedException();
		}

		private async Task<MediaInit> Init(HttpClient client, int length, string mediaType, string mediaCategory = "", string[] additionalUsers = null)
		{
			var url = $"{_endpoint}?command=INIT&total_bytes={length}&media_type={mediaType}";
			if (!string.IsNullOrEmpty(mediaCategory)) url += $"&media_category={mediaCategory}";
			if (additionalUsers != null & additionalUsers.Any()) url += $"&additional_users={string.Join(",", additionalUsers)}";
			var response = await client.PostAsync(url, null);
			return JsonConvert.DeserializeObject<MediaInit>(await response.Content.ReadAsStringAsync());
		}

		private async Task Append(HttpClient client, int mediaId, byte[] data, int segmentIndex)
		{
			var url = $"{_endpoint}?command=APPEND&media_id={mediaId}&media={data}segment_index={segmentIndex}";
			var response = await client.PostAsync(url, null);
			var responseBody = response.Content.ReadAsStringAsync();
		}

		private async Task<IEnumerable<byte>> GetBytes(byte[] image)
		{
			return image.AsEnumerable();
		}
	}
}
