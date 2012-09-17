namespace Github.Api.Framework
{
	public interface IGitHubApiSettings
	{
		string BaseUrl { get; set; }

		string Password { get; set; }

		string Token { get; set; }

		string Username { get; set; }
	}
}