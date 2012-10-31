namespace Github.Api.Framework
{
	public class GitHubApiCredentials : IGitHubApiCredentials
	{
		public string Password { get; set; }

		public string Token { get; set; }

		public string Username { get; set; }
	}
}