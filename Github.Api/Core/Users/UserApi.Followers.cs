using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Github.Api.Models;

namespace Github.Api.Core
{
	public partial class UserApi
	{
		public Task FollowAsync(string username)
		{
			return this.httpClient.PutAsync(string.Format("/user/following/{0}", username), null).ContinueWith(t =>
			{
				this.EnsureResponseSuccess(t.Result);
			});
		}

		public Task<IList<User>> GetFollowersAsync(User user)
		{
			return this.GetFollowersAsync(user.Login);
		}

		public Task<IList<User>> GetFollowersAsync(string username)
		{
			return this.GetFollowingCoreAsync(string.Format("/users/{0}/followers", username));
		}

		public Task<IList<User>> GetFollowingAsync(User user)
		{
			return this.GetFollowingAsync(user.Login);
		}

		public Task<IList<User>> GetFollowingAsync(string username)
		{
			return this.GetFollowingCoreAsync(string.Format("/users/{0}/following", username));
		}

		public Task UnFollowAsync(string username)
		{
			return this.httpClient.DeleteAsync(string.Format("/user/following/{0}", username)).ContinueWith(t =>
			{
				this.EnsureResponseSuccess(t.Result);
			});
		}

		private Task<IList<User>> GetFollowingCoreAsync(string url)
		{
			return this.GetAsync<IList<User>>(url);
		}
	}
}