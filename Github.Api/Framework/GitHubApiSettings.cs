namespace Github.Api.Framework
{
	public class GitHubApiSettings : IGitHubApiSettings
	{
		public string Username { get; set; }

		public string Password { get; set; }

		public string Token { get; set; }

		public string BaseUrl { get; set; }

		public GitHubApiSettings()
		{
			BaseUrl = "https://api.github.com";    
		}
	}
}
