namespace Github.Api.Framework
{
	public interface IGitHubApiCredentials
	{
		string Password { get; set; }

		string Token { get; set; }

		string Username { get; set; }
	}
}