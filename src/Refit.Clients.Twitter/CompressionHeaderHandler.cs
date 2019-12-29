namespace Refit.Clients
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public class CompressionHeaderHandler : DelegatingHandler
    {
        public CompressionHeaderHandler(HttpMessageHandler innerHandler) : base(innerHandler ?? new HttpClientHandler()) { }

        /// <inheritdoc/>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
