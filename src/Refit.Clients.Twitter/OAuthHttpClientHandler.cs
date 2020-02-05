using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Refit.Clients.Twitter
{
	internal class OAuthHttpClientHandler : DelegatingHandler
	{
		private readonly Func<HttpRequestMessage, Task<string>> getToken;

		public OAuthHttpClientHandler(Func<HttpRequestMessage, Task<string>> getToken, HttpMessageHandler innerHandler)
			: base(innerHandler ?? new HttpClientHandler())
		{
			this.getToken = getToken ?? throw new ArgumentNullException(nameof(getToken));
		}

		/// <inheritdoc/>
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			request.Headers.Add("User-Agent", "Refit.Clients.Twitter");

			// See if the request has an authorize header
			var auth = request.Headers.Authorization;
			if (auth != null)
			{
				var token = await getToken(request).ConfigureAwait(false);
				var header = new AuthenticationHeaderValue(auth.Scheme, token);
				request.Headers.Authorization = header;

				// Logger.Log($"Refit: {token}", Logger.RefitLogLocation);
			}

			return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
		}
	}
}
