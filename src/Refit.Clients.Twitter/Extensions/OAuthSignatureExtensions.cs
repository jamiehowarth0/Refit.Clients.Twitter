namespace Refit.Clients.Twitter.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    // using LoggingHelper;
    using Refit.Clients.Twitter.Extensions;

    static class OAuthSignatureExtensions
    {
        public static Task<string> GetToken(this HttpRequestMessage message, string consumerKey, string accessToken, string signingKey, Dictionary<string, string> requestParams)
        {
            var nonce = Guid.NewGuid().ToString("N");
            var now = TwitterClient.NowAsString;

            var oauthHeader = string.Concat(
                "realm=\"Twitter API\",",
                $"oauth_consumer_key=\"{consumerKey.UrlEncode()}\",",
                $"oauth_nonce=\"{nonce.UrlEncode()}\",",
                $"oauth_signature=\"{message.GenerateSignature(now, nonce, signingKey, requestParams).UrlEncode()}\",",
                $"oauth_signature_method=\"{"HMAC-SHA1".UrlEncode()}\",",
                $"oauth_timestamp=\"{now.UrlEncode()}\",",
                $"oauth_token=\"{accessToken.UrlEncode()}\",",
                $"oauth_version=\"{"1.0".UrlEncode()}\""
            );

            return Task.FromResult(oauthHeader);
        }

        internal static string GenerateSignature(this HttpRequestMessage message, string now, string nonce, string signingKey, Dictionary<string, string> requestParams)
        {
            var requestToBeSigned = string.Concat(
                $"{message.Method.ToString().ToUpperInvariant()}&",
                $"{message.RequestUri.NormalizeUrl().UrlEncode()}&" +
                $"{message.GetParameterString(requestParams, now, nonce)}");

            // Logger.Log($"Signature (Refit):{requestToBeSigned}", Logger.RefitLogLocation);

            return GetSignature(signingKey, requestToBeSigned);
        }

        public static string GetParameterString(this HttpRequestMessage message, Dictionary<string, string> requestParameters, string timeCalc, string nonce)
        {
            var sb = new StringBuilder();

            var rqParams = requestParameters;
            if (!rqParams.ContainsKey("oauth_nonce"))
            {
                rqParams.Add("oauth_nonce", nonce);
            }

            if (!rqParams.ContainsKey("oauth_timestamp"))
            {
                rqParams.Add("oauth_timestamp", timeCalc);
            }

            var additionalQueryParams = HttpUtility.ParseQueryString(message.RequestUri.Query);
            if (additionalQueryParams.Count > 0)
            {
                foreach (var queryItem in additionalQueryParams.AllKeys)
                {
                    if (!rqParams.ContainsKey(queryItem))
                    {
                        rqParams.Add(queryItem, additionalQueryParams[queryItem]);
                    }
                }
            }

            var rqSorted = rqParams.OrderBy(item => item.Key).ThenBy(item => item.Value.UrlEncode()).ToList();

            foreach (var item in rqSorted)
            {
                sb.Append($"{item.Key}={item.Value.UrlEncode()}".UrlEncode());
                if (rqSorted.ElementAt(rqSorted.Count - 1).Key != item.Key)
                {
                    sb.Append("&".UrlEncode());
                }
            }
            return sb.ToString();
        }

        private static string GetSignature(string signingKey, string requestToBeSigned)
        {
            using (var hmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(signingKey))) {
                return Convert.ToBase64String(hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(requestToBeSigned)));
            };
        }

    }
}
