using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Github.Api.Models;

namespace Github.Api.Core
{
	public class OrganizationApi : GitHubApi
	{
		public OrganizationApi(HttpClient httpClient)
			: base(httpClient)
		{
		}

		public Task<IEnumerable<Organization>> GetOrganizationsAsync()
		{
			return this.GetAsync<IEnumerable<Organization>>("/user/orgs");
		}
	}
}