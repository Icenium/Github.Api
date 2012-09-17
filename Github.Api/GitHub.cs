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

		public GitHub(IGitHubApiSettings gitHubApiSettings)
		{
			if (gitHubApiSettings == null)
			{
				throw new ArgumentNullException("gitHubApiSettings", "The Github settings provider cannot be null.");
			}

			if (!string.IsNullOrEmpty(gitHubApiSettings.Token))
			{
				this.httpClient = new HttpClient();
				this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", gitHubApiSettings.Token);
			}
			else if (!string.IsNullOrEmpty(gitHubApiSettings.Password) && !string.IsNullOrEmpty(gitHubApiSettings.Username))
			{
				this.httpClient = new HttpClient();
				string usernamePasswordToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture,
					"{0}:{1}", new object[] { gitHubApiSettings.Username, gitHubApiSettings.Password })));
				this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", usernamePasswordToken);
			}
			else
			{
			}

			this.httpClient.BaseAddress = new Uri(gitHubApiSettings.BaseUrl);
		}
	}
}