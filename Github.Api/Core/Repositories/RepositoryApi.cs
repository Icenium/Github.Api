using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Github.Api.Models;
using System.IO;

namespace Github.Api.Core
{
	public partial class RepositoryApi : GitHubApi
	{
		private static readonly Dictionary<RepositoryQueryDirection, string> queryDirections =
			new Dictionary<RepositoryQueryDirection, string>()
			{
				{ RepositoryQueryDirection.Ascending, "asc" },
				{ RepositoryQueryDirection.Descending, "desc" }
			};

		private static readonly Dictionary<RepositoryQuerySort, string> querySorts =
			new Dictionary<RepositoryQuerySort, string>()
			{
				{ RepositoryQuerySort.Created, "created" },
				{ RepositoryQuerySort.Pushed, "pushed" },
				{ RepositoryQuerySort.Updated, "updated" },
				{ RepositoryQuerySort.FullName, "full_name" }
			};
		private static readonly Dictionary<RepositoryQueryType, string> queryTypes =
			new Dictionary<RepositoryQueryType, string>()
			{
				{ RepositoryQueryType.All, "all" },
				{ RepositoryQueryType.Owner, "owner" },
				{ RepositoryQueryType.Public, "public" },
				{ RepositoryQueryType.Private, "private" },
				{ RepositoryQueryType.Member, "member" }
			};

		public RepositoryApi(HttpClient httpClient) : base(httpClient)
		{
		}

		public Task<Repository> CreateUserRepository(string name)
		{
			var queryContent = this.GetStringContent(new { name = name });
			return this.CreateUserRepositoryCore(queryContent);
		}

		public Task<Repository> CreateUserRepository(CreateRepositoryInfo createRepositoryInfo)
		{
			var queryContent = this.GetStringContent(createRepositoryInfo);
			return this.CreateUserRepositoryCore(queryContent);
		}

		public Task<Repository> CreateOrganizationRepository(string organization, string name)
		{
			var queryContent = this.GetStringContent(new { name = name });
			return this.CreateOrganizationRepositoryCore(organization, queryContent);
		}

		public Task<Repository> CreateOrganizationRepository(string organization, CreateRepositoryInfo createRepositoryInfo)
		{
			var queryContent = this.GetStringContent(createRepositoryInfo);
			return this.CreateOrganizationRepositoryCore(organization, queryContent);
		}

		public Task DeleteUserRepository(string username, string repositoryName)
		{
			return this.httpClient.DeleteAsync(string.Format("/repos/{0}/{1}", username, repositoryName)).ContinueWith(t =>
			{
				this.EnsureResponseSuccess(t.Result);
			});
		}

		public Task<IEnumerable<Repository>> GetOrganizationRepositoriesAsync(string organization, int pageSize)
		{
			return this.GetRepositoriesCore(string.Format("/orgs/{0}/repos?per_page={1}", organization, pageSize));
		}

		public Task<IEnumerable<Repository>> GetOrganizationRepositoriesAsync(string organization, RepositoryQueryType type, int pageSize)
		{
			if (type == RepositoryQueryType.Owner)
			{
				throw new NotSupportedException();
			}

			return this.GetRepositoriesCore(string.Format("/orgs/{0}/repos?type={1}&per_page={2}", organization, queryTypes[type], pageSize));
		}

		public Task<IEnumerable<Repository>> GetRepositoriesAsync()
		{
			return this.GetRepositoriesCore("/user/repos");
		}

		public Task<IEnumerable<Repository>> GetRepositoriesAsync(RepositoryQueryType type)
		{
			return this.GetRepositoriesCore(string.Format("/user/repos?type={0}", queryTypes[type]));
		}

		public Task<IEnumerable<Repository>> GetRepositoriesAsync(RepositoryQueryType type,
			RepositoryQuerySort sort, RepositoryQueryDirection direction)
		{
			return this.GetRepositoriesCore(string.Format("/user/repos?type={0}&sort={1}&direction={2}",
				queryTypes[type], querySorts[sort], queryDirections[direction]));
		}

		public Task<IEnumerable<Repository>> GetUserRepositoriesAsync(string username)
		{
			return this.GetRepositoriesCore(string.Format("/users/{0}/repos", username));
		}

		public Task<Stream> GetRepositoryArchiveAsync(string repositoryFullName, RepositoryArchiveType archiveType)
		{
			return this.GetAsStreamAsync(string.Format("/repos/{0}/{1}", repositoryFullName, archiveType.ToString().ToLower()));
		}

		public Task<IEnumerable<Repository>> GetUserRepositoriesAsync(string username, RepositoryQueryType type)
		{
			if (type == RepositoryQueryType.Private && type == RepositoryQueryType.Public)
			{
				throw new NotSupportedException();
			}

			return this.GetRepositoriesCore(string.Format("/users/{0}/repos?type={1}", username, queryTypes[type]));
		}

		public Task<IEnumerable<Repository>> GetUserRepositoriesAsync(string username, RepositoryQueryType type,
			RepositoryQuerySort sort, RepositoryQueryDirection direction)
		{
			return this.GetRepositoriesCore(string.Format("/users/{0}/repos?type={1}&sort={2}&direction={3}",
				queryTypes[type], querySorts[sort], queryDirections[direction]));
		}

		private Task<Repository> CreateUserRepositoryCore(StringContent queryContent)
		{
			return this.CreateAsync("/user/repos", queryContent, this.ReadErrorMessage<Repository>);
		}

		private Task<Repository> CreateOrganizationRepositoryCore(string organization, StringContent queryContent)
		{
			return this.CreateAsync(string.Format("/orgs/{0}/repos", organization), queryContent, this.ReadErrorMessage<Repository>);
		}

		private Task<IEnumerable<Repository>> GetRepositoriesCore(string url)
		{
			return this.GetAsync<IEnumerable<Repository>>(url);
		}
	}
}