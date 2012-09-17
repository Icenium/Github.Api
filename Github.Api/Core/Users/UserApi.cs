using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Github.Api.Models;

namespace Github.Api.Core
{
	public partial class UserApi : GitHubApi
	{
		public UserApi(HttpClient httpClient) : base(httpClient)
		{
		}

		public Task<User> FindUserByEmail(string email)
		{
			return this.GetUserCore(string.Format("/user/search/{0}", email));
		}

		public Task<User> GetUser(string username)
		{
			return this.GetUserCore(string.Format("/users/{0}", username));
		}

		public Task<User> GetUserCore(string url)
		{
			return this.GetAsync<User>(url);
		}

		public Task<IList<User>> SearchUser(string username)
		{
			return this.GetAsync<IList<User>>(string.Format("/user/search/{0}", username));
		}
	}
}