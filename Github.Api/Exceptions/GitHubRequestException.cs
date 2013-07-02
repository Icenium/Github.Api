using System;
using System.Linq;
using System.Net.Http;

namespace Github.Api
{
	public class GitHubRequestException : HttpRequestException
	{
		public HttpResponseMessage HttpResponseMessage { get; set; }

		public GitHubRequestException(HttpResponseMessage httpResponseMessage)
			: this(httpResponseMessage, null)
		{
		}

		public GitHubRequestException(HttpResponseMessage httpResponseMessage, string errorMessage)
			: base(errorMessage)
		{
			this.HttpResponseMessage = httpResponseMessage;
		}
	}
}
