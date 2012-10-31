using System;
using System.Linq;
using System.Net.Http;

namespace Github.Api.Extensions
{
	public static class HttpResponseMessageExtensions
	{
		public static void EnsureResponseSuccessStatusCode(this HttpResponseMessage httpResponseMessage)
		{
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				return;
			}
			else
			{
				throw new GitHubRequestException(httpResponseMessage);
			}
		}
	}
}
