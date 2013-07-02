using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Github.Api.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Github.Api.Core
{
	public abstract class GitHubApi
	{
		protected static readonly MediaTypeFormatterCollection mediaTypeFormatterCollection = new MediaTypeFormatterCollection();

		protected HttpClient httpClient;

		protected GitHubApi(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public Task<T> CreateAsync<T>(string url, StringContent queryContent, Func<HttpResponseMessage, Task<T>> parseErrors)
		{
			return this.httpClient.PostAsync(url, queryContent).ContinueWith(t =>
			{
				this.EnsureAuthorizationAndRateLimit(t.Result);

				if (t.Result.StatusCode != System.Net.HttpStatusCode.Created)
				{
					return parseErrors(t.Result);
				}

				return t.Result.Content.ReadAsAsync<T>(mediaTypeFormatterCollection);
			}).Unwrap();
		}

		public Task<dynamic> GetDynamicAsync(string url)
		{
			return this.httpClient.GetAsync(url).ContinueWith(t =>
			{
				this.EnsureAuthorizationAndRateLimit(t.Result);
				t.Result.EnsureSuccessStatusCode();

				return t.Result.Content.ReadAsStringAsync().ContinueWith(task =>
				{
					return (dynamic)JValue.Parse(task.Result);
				});
			}).Unwrap();
		}

		public Task<T> GetAsync<T>(string url)
		{
			return this.httpClient.GetAsync(url).ContinueWith(t =>
			{
				this.EnsureAuthorizationAndRateLimit(t.Result);

				t.Result.EnsureResponseSuccessStatusCode();
				return t.Result.Content.ReadAsAsync<T>(mediaTypeFormatterCollection);
			}).Unwrap();
		}

		protected static void CheckRateLimit(HttpResponseMessage httpResponseMessage)
		{
			var headers = httpResponseMessage.Headers;
			var rateLimits = headers.Where(x => x.Key.StartsWith("X-RateLimit"));
			var actualRateLimit = rateLimits.Single(x => x.Key.EndsWith("-Limit"));
			var remainingRateLimit = rateLimits.Single(x => x.Key.EndsWith("-Remaining"));

			var rateLimit = Convert.ToInt32(actualRateLimit.Value.Single());

			var rateLimitRemaining = Convert.ToInt32(remainingRateLimit.Value.Single());

			Debug.WriteLine(string.Format("Current remaining rate limit: {0}", rateLimitRemaining));

			if (rateLimitRemaining <= 0)
			{
				throw new GitHubRequestException(httpResponseMessage, string.Format("Github API rate limit ({0}) has been reached.", rateLimit));
			}
		}

		protected static void EnsureAuthorized(HttpResponseMessage httpResponseMessage)
		{
			if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
			{
				throw new GitHubRequestException(httpResponseMessage, "Access to this method requires an authenticated user");
			}
		}

		protected void EnsureAuthorizationAndRateLimit(HttpResponseMessage httpResponseMessage)
		{
			EnsureAuthorized(httpResponseMessage);
			CheckRateLimit(httpResponseMessage);
		}

		protected void EnsureResponseSuccess(HttpResponseMessage httpResponseMessage)
		{
			this.EnsureAuthorizationAndRateLimit(httpResponseMessage);
			httpResponseMessage.EnsureSuccessStatusCode();
		}

		protected StringContent GetStringContent(object objectToSerialize)
		{
			return new StringContent(JValue.FromObject(objectToSerialize).ToString(),
				Encoding.UTF8, "application/json");
		}

		protected Task<T> ReadErrorMessage<T>(HttpResponseMessage response)
		{
			return response.Content.ReadAsStringAsync().ContinueWith(task =>
			{
				var result = (dynamic)JValue.Parse(task.Result);
				var taskCompletionSource = new TaskCompletionSource<T>();
				taskCompletionSource.SetException(new HttpRequestException(result.message.Value));
				return taskCompletionSource.Task;
			}).Unwrap();
		}

		protected Task<T> ReadErrors<T>(HttpResponseMessage response)
		{
			return response.Content.ReadAsStringAsync().ContinueWith(task =>
			{
				var result = (dynamic)JValue.Parse(task.Result);
				var exceptions = new List<HttpRequestException>();
				foreach (var error in result.errors)
				{
					exceptions.Add(new HttpRequestException(error.message.Value));
				}
				var taskCompletionSource = new TaskCompletionSource<T>();
				taskCompletionSource.SetException(exceptions);
				return taskCompletionSource.Task;
			}).Unwrap();
		}
	}
}