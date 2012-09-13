using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Github.Api.Extensions
{
	public static class HttpClientExtensions
	{
		private static readonly MediaTypeFormatterCollection mediaTypeFormatterCollection = new MediaTypeFormatterCollection();

		public static Task<T> GetAsync<T>(this HttpClient client, string url, Action<HttpResponseMessage> assertLogic)
		{
			return client.GetAsync(url).ContinueWith(t =>
			{
				assertLogic(t.Result);

				return t.Result.Content.ReadAsAsync<T>(mediaTypeFormatterCollection);
			}).Unwrap();
		}
	}
}
