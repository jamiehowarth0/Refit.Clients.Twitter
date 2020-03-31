// <copyright file="CompressionHeaderHandler.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Refit.Clients.Twitter
{
	internal class CompressionHeaderHandler : DelegatingHandler
	{
		public CompressionHeaderHandler(HttpMessageHandler innerHandler)
			: base(innerHandler ?? new HttpClientHandler())
		{

		}

		/// <inheritdoc/>
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				return new HttpResponseMessage(HttpStatusCode.InternalServerError);
			}

			request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
			request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
		}
	}
}
