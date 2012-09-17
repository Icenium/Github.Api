using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Github.Api.Models;

namespace Github.Api.Core
{
	public partial class RepositoryApi
	{
		public Task AddCollaborator(string repositoryOwnerUsername, string repositoryName, string usernameToAdd)
		{
			return this.httpClient.PutAsync(string.Format("/repos/{0}/{1}/collaborators/{2}",
				repositoryOwnerUsername, repositoryName, usernameToAdd), null).ContinueWith(t =>
				{
					this.EnsureResponseSuccess(t.Result);
				});
		}

		public Task<IList<User>> GetCollaborators(string username, string repositoryName)
		{
			return this.GetAsync<IList<User>>(string.Format("/repos/{0}/{1}/collaborators",
				username, repositoryName));
		}

		public Task<bool> IsUserCollaborator(string repositoryOwnerUsername, string repositoryName, string usernameToCheck)
		{
			return this.httpClient.GetAsync(string.Format("/repos/{0}/{1}/collaborators/{2}",
				repositoryOwnerUsername, repositoryName, usernameToCheck)).ContinueWith(t =>
				{
					this.EnsureAuthorizationAndRateLimit(t.Result);

					if (t.Result.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return true;
					}
					else if (t.Result.StatusCode == System.Net.HttpStatusCode.NotFound)
					{
						return false;
					}
					else
					{
						throw new GitHubResponseException(string.Format("Unexpected StatusCode Recieved: {0}", t.Result.StatusCode));
					}
				});
		}

		public Task RemoveCollaborator(string repositoryOwnerUsername, string repositoryName, string usernameToRemove)
		{
			return this.httpClient.DeleteAsync(string.Format("/repos/{0}/{1}/collaborators/{2}",
				repositoryOwnerUsername, repositoryName, usernameToRemove)).ContinueWith(t =>
				{
					this.EnsureResponseSuccess(t.Result);
				});
		}
	}
}