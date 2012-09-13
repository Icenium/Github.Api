using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Github.Api.Extensions;
using Github.Api.Models;
using Newtonsoft.Json.Linq;

namespace Github.Api.Core
{
	public partial class UserApi
	{
		public Task<IList<GitHubSshKey>> GetKeysAsync()
		{
			return this.httpClient.GetAsync<IList<GitHubSshKey>>("/user/keys", this.assertQuerySuccess);
		}

		public Task<GitHubSshKey> GetKeyAsync(string id)
		{
			return this.httpClient.GetAsync<GitHubSshKey>(string.Format("/user/keys/{0}", id), this.assertQuerySuccess);
		}

		public Task<GitHubSshKey> CreateKeyAsync(string title, string key)
		{
			var queryContent = new StringContent(JValue.FromObject(new { title = title, key = key }).ToString(), 
				Encoding.UTF8, "application/json");
			return this.httpClient.PostAsync("/user/keys", queryContent).ContinueWith(t =>
			{
				EnsureAuthorized(t.Result.StatusCode);
				CheckRateLimit(t.Result.Headers);

				if (t.Result.StatusCode != System.Net.HttpStatusCode.Created)
				{
					return this.ReadErrors<GitHubSshKey>(t.Result);
				}

				return t.Result.Content.ReadAsAsync<GitHubSshKey>(mediaTypeFormatterCollection);
			}).Unwrap();
		}

		public Task<GitHubSshKey> UpdateKeyAsync(string title, string key, string id)
		{
			var queryContent = new StringContent(JValue.FromObject(new { title = title, key = key }).ToString(),
				Encoding.UTF8, "application/json");
			var requestMessage = new HttpRequestMessage(new HttpMethod("Patch"), string.Format("/user/keys/{0}", id))
			{
				Content = queryContent
			};
			return this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None)
				.ContinueWith(t =>
			{
				this.assertQuerySuccess(t.Result);

				return t.Result.Content.ReadAsAsync<GitHubSshKey>(mediaTypeFormatterCollection);
			}).Unwrap();
		}

		public Task DeleteKeyAsync(string id)
		{
			return this.httpClient.DeleteAsync(string.Format("/user/keys/{0}", id))
				.ContinueWith(t =>
				{
					this.assertQuerySuccess(t.Result);
				});
		}
	}
}
