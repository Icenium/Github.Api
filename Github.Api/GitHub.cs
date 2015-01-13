using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Github.Api.Core;
using Github.Api.Framework;

namespace Github.Api
{
	public class GitHub
	{
		public const string ServiceAddress = "https://api.github.com";

		private readonly HttpClient httpClient;

		public AuthorizationApi Authorization
		{
			get
			{
				return new AuthorizationApi(this.httpClient);
			}
		}

		public Uri BaseAddress
		{
			get
			{
				return this.httpClient.BaseAddress;
			}
			set
			{
				this.httpClient.BaseAddress = value;
			}
		}

		public OrganizationApi Organizations
		{
			get
			{
				return new OrganizationApi(this.httpClient);
			}
		}

		public RepositoryApi Repositories
		{
			get
			{
				return new RepositoryApi(this.httpClient);
			}
		}

		public UserApi Users
		{
			get
			{
				return new UserApi(this.httpClient);
			}
		}

		public SearchApi Search
		{
			get
			{
				return new SearchApi(this.httpClient);
			}
		}

		public GitHub(HttpClient httpClient)
		{
			this.httpClient = httpClient;
			this.httpClient.BaseAddress = new Uri(ServiceAddress);
		}

		public GitHub()
			: this(new HttpClient())
		{

		}

		public GitHub(HttpClient httpClient, IGitHubApiCredentials githubApiCredentials)
			: this(httpClient)
		{
			if (githubApiCredentials == null)
			{
				throw new ArgumentNullException("gitHubApiSettings", "The Github settings provider cannot be null.");
			}

			this.UpdateCrentials(githubApiCredentials);
		}

		public GitHub(IGitHubApiCredentials githubApiCredentials)
			: this(new HttpClient(), githubApiCredentials)
		{

		}

		public void UpdateCrentials(IGitHubApiCredentials githubApiCredentials)
		{
			if (!string.IsNullOrEmpty(githubApiCredentials.Token))
			{
				this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", githubApiCredentials.Token);
			}
			else if (!string.IsNullOrEmpty(githubApiCredentials.Username))
			{
				string usernamePasswordToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture,
					"{0}:{1}", new object[] { githubApiCredentials.Username, githubApiCredentials.Password })));
				this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", usernamePasswordToken);
			}
		}
	}
}