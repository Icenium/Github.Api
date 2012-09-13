namespace Github.Api.Framework
{
	public interface IGitHubApiSettings
	{
		string Username { get; set; }

		string Password { get; set; }

		string Token { get; set; }

		string BaseUrl { get; set; }
	}
}