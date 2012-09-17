namespace Github.Api.Framework
{
	public class GitHubApiSettings : IGitHubApiSettings
	{
		public string BaseUrl { get; set; }

		public string Password { get; set; }

		public string Token { get; set; }

		public string Username { get; set; }

		public GitHubApiSettings()
		{
			this.BaseUrl = "https://api.github.com";    
		}
	}
}