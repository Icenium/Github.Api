using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Github.Api.Models;

namespace Github.Api.Core
{
	public class AuthorizationApi : GitHubApi
	{
		public AuthorizationApi(HttpClient httpClient) : base(httpClient)
		{
		}

		public Task<Authorization> CreateAuthorizationAsync(IEnumerable<string> scopes, string note, string noteUrl)
		{
			var queryContent = this.GetStringContent(new { scopes = scopes, note = note, note_url = noteUrl });
			return this.CreateAuthorizationAsyncCore(queryContent);
		}

		public Task<Authorization> CreateAuthorizationAsync(IEnumerable<string> scopes)
		{
			var queryContent = this.GetStringContent(new { scopes = scopes });
			return this.CreateAuthorizationAsyncCore(queryContent);
		}

		public Task DeleteAuthorization(string id)
		{
			return this.httpClient.DeleteAsync(string.Format("/authorizations/{0}", id)).ContinueWith(t =>
			{
				this.EnsureAuthorizationAndRateLimit(t.Result);
				t.Result.EnsureSuccessStatusCode();
			});
		}

		public Task<Authorization> GetAuthorizationAsync(string id)
		{
			return this.GetAsync<Authorization>(string.Format("/authorizations/{0}", id));
		}

		public Task<IList<Authorization>> GetAuthorizationsAsync()
		{
			return this.GetAsync<IList<Authorization>>("/authorizations");
		}

		private Task<Authorization> CreateAuthorizationAsyncCore(StringContent queryContent)
		{
			return this.CreateAsync("/authorizations", queryContent, this.ReadErrorMessage<Authorization>);
		}
	}
}