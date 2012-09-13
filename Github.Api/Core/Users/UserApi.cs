using System.Collections.Generic;
using System.Threading.Tasks;
using Github.Api.Extensions;
using Github.Api.Models;
using System.Net.Http;

namespace Github.Api.Core
{
	public partial class UserApi : GitHubApi
	{
		public UserApi(HttpClient httpClient)
			: base(httpClient)
		{
		}

		public Task<User> GetUserCore(string url)
		{
			return this.httpClient.GetAsync<User>(url, assertQuerySuccess);
		}

		public Task<User> GetUser(string username)
		{
			return this.GetUserCore(string.Format("/users/{0}", username));
		}

		public Task<User> FindUserByEmail(string email)
		{
			return this.GetUserCore(string.Format("/user/search/{0}", email));
		}

		public Task<IList<User>> SearchUser(string username)
		{
			return this.httpClient.GetAsync<IList<User>>(string.Format("/user/search/{0}", username), assertQuerySuccess);
		}
	}
}