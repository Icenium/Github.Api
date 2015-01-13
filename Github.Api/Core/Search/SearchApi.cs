using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Github.Api.Models;
using Github.Api.Core.Search;

namespace Github.Api.Core
{
	public class SearchApi : GitHubApi
	{
		public SearchApi(HttpClient httpClient) : base(httpClient)
		{
		}

		public Task<SearchRepositoryResult> FindRepositories(string filter, string organization, SearchTargetType targetType = SearchTargetType.Name, int pageSize = 100)
		{
			return this.GetAsync<SearchRepositoryResult>(string.Format("/search/repositories?q={0}+fork:true+user:{1}+in:{2}&per_page={3}", filter, organization, targetType, pageSize));
		}
	}
}
