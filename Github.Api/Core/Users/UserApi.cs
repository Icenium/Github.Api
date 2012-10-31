using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Github.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

		public Task<User> GetAuthenticatedUser()
		{
			return this.GetUserCore("/user");
		}

		public Task<User> GetUser(string username)
		{
			return this.GetUserCore(string.Format("/users/{0}", username));
		}

		public Task<User> GetUserCore(string url)
		{
			return this.GetAsync<User>(url);
		}

		public Task<IEnumerable<User>> SearchUser(string username)
		{
			return this.GetDynamicAsync(string.Format("/legacy/user/search/{0}", username)).ContinueWith(t =>
				{
					var serializer = JsonSerializer.Create(new JsonSerializerSettings());
					var users = ((JObject)t.Result)["users"];
					var reader = new JTokenReader(users);
					return serializer.Deserialize<IEnumerable<User>>(reader);
				});
		}
	}
}