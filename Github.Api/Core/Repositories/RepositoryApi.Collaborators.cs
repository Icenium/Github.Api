using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
					return EnsureReponseHasNoContent(t.Result);
				}).Unwrap();
		}

		public Task<IEnumerable<User>> GetCollaborators(string username, string repositoryName)
		{
			return this.GetAsync<IEnumerable<User>>(string.Format("/repos/{0}/{1}/collaborators",
				username, repositoryName)).ContinueWith(t =>
					{
						if (t.IsFaulted)
						{
							var exception = (GitHubRequestException)t.Exception.InnerException;
							if (exception.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
							{
								throw new InvalidOperationException("This repository is not part of your GitHub repositories");
							}
						}

						return t;
					}).Unwrap();
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
						throw new GitHubRequestException(t.Result);
					}
				});
		}

		public Task RemoveCollaborator(string repositoryOwnerUsername, string repositoryName, string usernameToRemove)
		{
			return this.httpClient.DeleteAsync(string.Format("/repos/{0}/{1}/collaborators/{2}",
			repositoryOwnerUsername, repositoryName, usernameToRemove)).ContinueWith(t =>
			{
				return EnsureReponseHasNoContent(t.Result);
			}).Unwrap();
		}
  
		private Task EnsureReponseHasNoContent(HttpResponseMessage responseMessage)
		{
			this.EnsureAuthorizationAndRateLimit(responseMessage);

			if (responseMessage.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				return this.ReadErrorMessage<object>(responseMessage);
			}
			else
			{
				var taskCompletionSource = new TaskCompletionSource<object>();
				taskCompletionSource.SetResult(null);
				return taskCompletionSource.Task;
			}
		}
	}
}