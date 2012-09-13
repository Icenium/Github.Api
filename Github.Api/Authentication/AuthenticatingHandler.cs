using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Github.Api.Authentication
{
	// Not currently used as token authentication is passing through default headers.
	public class AuthenticatingHandler : DelegatingHandler
	{
		private const string AccessTokenKeyName = "access_token"; 
		private readonly string accessToken;

		public AuthenticatingHandler(string accessToken)
			: this(new HttpClientHandler(), accessToken)
		{
		}

		public AuthenticatingHandler(HttpMessageHandler handler, string accessToken)
			: base(handler)
		{
			this.accessToken = accessToken;
		}

		private string GetAccessTokenKeyValuePair(string query)
		{
			query = query + string.Format("{0}={1}", AccessTokenKeyName, this.accessToken);
			return query;
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var query = request.RequestUri.Query;

			if (query == string.Empty)
			{
				query = "?" + GetAccessTokenKeyValuePair(query);
			}
			else if (!query.Contains(AccessTokenKeyName))
			{
				query = "&" + GetAccessTokenKeyValuePair(query);
			}

			request.RequestUri = new Uri(request.RequestUri.GetLeftPart(UriPartial.Path) + query);

			return base.SendAsync(request, cancellationToken);
		}
	}
}
