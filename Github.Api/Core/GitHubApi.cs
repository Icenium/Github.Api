using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Github.Api.Core
{
	public abstract class GitHubApi
	{
		protected static readonly MediaTypeFormatterCollection mediaTypeFormatterCollection = new MediaTypeFormatterCollection();
		protected Action<HttpResponseMessage> assertQuerySuccess = (httpResponseMessage) =>
			{
				EnsureAuthorized(httpResponseMessage.StatusCode);
				CheckRateLimit(httpResponseMessage.Headers);
				httpResponseMessage.EnsureSuccessStatusCode();
			};
		protected HttpClient httpClient;

		protected GitHubApi(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}


		protected static void EnsureAuthorized(HttpStatusCode statusCode)
		{
			if (statusCode == System.Net.HttpStatusCode.Unauthorized)
			{
				throw new GitHubAuthorizationException("Access to this method requires an authenticated user");
			}
		}

		protected static void CheckRateLimit(HttpResponseHeaders headers)
		{
			var rateLimits = headers.Where(x => x.Key.StartsWith("X-RateLimit"));
			var actualRateLimit = rateLimits.Single(x => x.Key.EndsWith("-Limit"));
			var remainingRateLimit = rateLimits.Single(x => x.Key.EndsWith("-Remaining"));

			var rateLimit = Convert.ToInt32(actualRateLimit.Value.Single());

			var rateLimitRemaining = Convert.ToInt32(remainingRateLimit.Value.Single());

			Debug.WriteLine(string.Format("Current remaining rate limit: {0}", rateLimitRemaining));

			if (rateLimitRemaining <= 0)
				throw new GitHubResponseException(string.Format("Github API rate limit ({0}) has been reached.", rateLimit));
		}

		protected Task<T> ReadErrorMessage<T>(HttpResponseMessage response)
		{
			return response.Content.ReadAsStringAsync().ContinueWith(task =>
			{
				var result = (dynamic)JValue.Parse(task.Result);
				var taskCompletionSource = new TaskCompletionSource<T>();
				taskCompletionSource.SetException(new GitHubResponseException(result.message.Value));
				return taskCompletionSource.Task;
			}).Unwrap();
		}

		protected Task<T> ReadErrors<T>(HttpResponseMessage response)
		{
			return response.Content.ReadAsStringAsync().ContinueWith(task =>
			{
				var result = (dynamic)JValue.Parse(task.Result);
				var exceptions = new List<Exception>();
				foreach (var error in result.errors)
				{
					exceptions.Add(new GitHubResponseException(error.message.Value));
				}
				var taskCompletionSource = new TaskCompletionSource<T>();
				taskCompletionSource.SetException(exceptions);
				return taskCompletionSource.Task;
			}).Unwrap();
		}
	}
}
