using System;
using System.Linq;
using System.Net.Http;

namespace Github.Api
{
	public class GitHubRequestException : HttpRequestException
	{
		public HttpResponseMessage HttpResponseMessage { get; set; }

		public GitHubRequestException(HttpResponseMessage httpResponseMessage) :base()
		{
			this.HttpResponseMessage = httpResponseMessage;
		}
	}
}
