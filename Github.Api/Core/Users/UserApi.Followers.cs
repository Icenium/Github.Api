using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Github.Api.Extensions;
using Github.Api.Models;

namespace Github.Api.Core
{
	public partial class UserApi
	{
		public Task<IList<Following>> GetFollowingAsync(User user)
		{
			return GetFollowingAsync(user.Login);
		}

		private Task<IList<Following>> GetFollowingCoreAsync(string url)
		{
			return this.httpClient.GetAsync<IList<Following>>(url, this.assertQuerySuccess);
		}

		public Task<IList<Following>> GetFollowingAsync(string username)
		{
			return GetFollowingCoreAsync(string.Format("/users/{0}/following", username));
		}

		public Task<IList<Following>> GetFollowersAsync(User user)
		{
			return GetFollowersAsync(user.Login);
		}

		public Task<IList<Following>> GetFollowersAsync(string username)
		{
			return GetFollowingCoreAsync(string.Format("/users/{0}/followers", username));
		}

		public Task FollowAsync(string username)
		{
			return this.httpClient.PutAsync(string.Format("/user/following/{0}", username), null).ContinueWith(t =>
			{
				this.assertQuerySuccess(t.Result);
			});
		}

		public Task UnFollowAsync(string username)
		{
			return this.httpClient.DeleteAsync(string.Format("/user/following/{0}", username)).ContinueWith(t =>
			{
				this.assertQuerySuccess(t.Result);
			});
		}
	}
}
