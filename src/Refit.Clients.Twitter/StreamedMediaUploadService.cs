namespace Refit.Clients.Twitter
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class StreamedMediaUploadService
    {
        private string _consumerKey;
        private string _consumerSecret;
        private string _accessToken;
        private string _accessTokenSecret;

        internal StreamedMediaUploadService(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
            _accessTokenSecret = accessTokenSecret;
        }

        public async Task<ulong> Upload(byte[] content, string contentType)
        {
            using (var client = new HttpClient())
            {
                // client.PostAsync("https://upload.twitter.com/1.1/media/upload.json");
            }

            throw new NotImplementedException();
            // batch into 4mb chunks
        }

        private async Task<IEnumerable<byte>> GetBytes(byte[] image)
        {
            int counter = 0;
            int maxLength = image.Length;

            throw new NotImplementedException();
        }
    }
}
