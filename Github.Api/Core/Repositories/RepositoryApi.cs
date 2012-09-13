using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Github.Api.Models;
using Github.Api.Extensions;
using Newtonsoft.Json.Linq;

namespace Github.Api.Core
{
	public partial class RepositoryApi : GitHubApi
	{
		private static readonly Dictionary<RepositoryQueryType, string> queryTypes =
			new Dictionary<RepositoryQueryType, string>()
		{
		        {RepositoryQueryType.All,"all"},
		        {RepositoryQueryType.Owner, "owner"},
		        {RepositoryQueryType.Public, "public"},
		        {RepositoryQueryType.Private, "private"},
		        {RepositoryQueryType.Member, "member"}
		};
		private static readonly Dictionary<RepositoryQuerySort, string> querySorts =
			new Dictionary<RepositoryQuerySort, string>()
		{
		        {RepositoryQuerySort.Created,"created"},
		        {RepositoryQuerySort.Pushed,"pushed"},
		        {RepositoryQuerySort.Updated,"updated"},
		        {RepositoryQuerySort.FullName,"full_name"}
		};
		private static readonly Dictionary<RepositoryQueryDirection, string> queryDirections =
			new Dictionary<RepositoryQueryDirection, string>()
		{
		        {RepositoryQueryDirection.Ascending,"asc"},
		        {RepositoryQueryDirection.Descending,"desc"}
		};

		public RepositoryApi(HttpClient httpClient)
			: base(httpClient)
		{
		}

		private Task<IList<Repository>> GetRepositoriesCore(string url)
		{
			return this.httpClient.GetAsync<IList<Repository>>(url, assertQuerySuccess);
		}

		public Task<IList<Repository>> GetRepositoriesAsync()
		{
			return GetRepositoriesCore("/user/repos");
		}

		public Task<IList<Repository>> GetRepositoriesAsync(RepositoryQueryType type)
		{
			return GetRepositoriesCore(string.Format("/user/repos?type={0}", queryTypes[type]));
		}

		public Task<IList<Repository>> GetRepositoriesAsync(RepositoryQueryType type, 
			RepositoryQuerySort sort, RepositoryQueryDirection direction)
		{
			return GetRepositoriesCore(string.Format("/user/repos?type={0}&sort={1}&direction={2}",
				queryTypes[type], querySorts[sort], queryDirections[direction]));
		}

		public Task<IList<Repository>> GetUserRepositoriesAsync(string username)
		{
			return GetRepositoriesCore(string.Format("/users/{0}/repos", username));
		}

		public Task<IList<Repository>> GetUserRepositoriesAsync(string username, RepositoryQueryType type)
		{
			if (type == RepositoryQueryType.Private && type == RepositoryQueryType.Public)
			{
				throw new NotSupportedException();
			}

			return GetRepositoriesCore(string.Format("/users/{0}/repos?type={1}", username, queryTypes[type]));
		}

		public Task<IList<Repository>> GetUserRepositoriesAsync(string username, RepositoryQueryType type,
			RepositoryQuerySort sort, RepositoryQueryDirection direction)
		{
			return GetRepositoriesCore(string.Format("/users/{0}/repos?type={1}&sort={2}&direction={3}",
				queryTypes[type], querySorts[sort], queryDirections[direction]));
		}

		public Task<IList<Repository>> GetOrganizationRepositoriesAsync(string organization)
		{
			return GetRepositoriesCore(string.Format("/orgs/{0}/repos", organization));
		}

		public Task<IList<Repository>> GetOrganizationRepositoriesAsync(string organization, RepositoryQueryType type)
		{
			if (type == RepositoryQueryType.Owner)
			{
				throw new NotSupportedException();
			}

			return GetRepositoriesCore(string.Format("/orgs/{0}/repos?type={1}", organization, queryTypes[type]));
		}

		private Task<Repository> CreateUserRepositoryCore(StringContent queryContent)
		{
			return this.httpClient.PostAsync("/user/repos", queryContent).ContinueWith(t =>
			{
				EnsureAuthorized(t.Result.StatusCode);
				CheckRateLimit(t.Result.Headers);

				if (t.Result.StatusCode != System.Net.HttpStatusCode.Created)
				{
					return this.ReadErrorMessage<Repository>(t.Result);
				}
				return t.Result.Content.ReadAsAsync<Repository>(mediaTypeFormatterCollection);
			}).Unwrap();
		}

		public Task<Repository> CreateUserRepository(string name)
		{
			var queryContent = new StringContent(JValue.FromObject(new { name = name }).ToString(),
				Encoding.UTF8, "application/json");
			return this.CreateUserRepositoryCore(queryContent);
		}

		public Task<Repository> CreateUserRepository(CreateRepositoryInfo createRepositoryInfo)
		{
			var queryContent = new StringContent(JValue.FromObject(createRepositoryInfo).ToString(),
				   Encoding.UTF8, "application/json");
			return this.CreateUserRepositoryCore(queryContent);
		}

		public Task DeleteUserRepository(string username, string repositoryName)
		{
			return this.httpClient.DeleteAsync(string.Format("/repos/{0}/{1}", username, repositoryName)).ContinueWith(t =>
			{
				this.assertQuerySuccess(t.Result);
			});
		}
	}
}
