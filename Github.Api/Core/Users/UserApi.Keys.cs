using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Github.Api.Models;

namespace Github.Api.Core
{
	public partial class UserApi
	{
		public Task<SshKey> CreateKeyAsync(string title, string key)
		{
			var queryContent = this.GetStringContent(new { title = title, key = key });
			return this.CreateAsync<SshKey>("/user/keys", queryContent, this.ReadErrors<SshKey>);
		}

		public Task DeleteKeyAsync(string id)
		{
			return this.httpClient.DeleteAsync(string.Format("/user/keys/{0}", id))
					   .ContinueWith(t =>
					   {
						   this.EnsureResponseSuccess(t.Result);
					   });
		}

		public Task<SshKey> GetKeyAsync(string id)
		{
			return this.GetAsync<SshKey>(string.Format("/user/keys/{0}", id));
		}

		public Task<IList<SshKey>> GetKeysAsync()
		{
			return this.GetAsync<IList<SshKey>>("/user/keys");
		}

		public Task<SshKey> UpdateKeyAsync(string title, string key, string id)
		{
			var queryContent = this.GetStringContent(new { title = title, key = key });
			var requestMessage = new HttpRequestMessage(new HttpMethod("Patch"), string.Format("/user/keys/{0}", id))
			{
				Content = queryContent
			};
			return this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None)
					   .ContinueWith(t =>
					   {
						   this.EnsureResponseSuccess(t.Result);

						   return t.Result.Content.ReadAsAsync<SshKey>(mediaTypeFormatterCollection);
					   }).Unwrap();
		}
	}
}