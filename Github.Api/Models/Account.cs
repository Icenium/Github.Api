using System;
using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class Account
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "login")]
		public string Login { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "avatar_url")]
		public string AvatarUrl { get; set; }

		[JsonProperty(PropertyName = "html_url")]
		public string HtmlUrl { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "company")]
		public string Company { get; set; }

		[JsonProperty(PropertyName = "blog")]
		public string Blog { get; set; }

		[JsonProperty(PropertyName = "location")]
		public string Location { get; set; }

		[JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[JsonProperty(PropertyName = "public_repos")]
		public int PublicRepos { get; set; }

		[JsonProperty(PropertyName = "public_gists")]
		public int PublicGists { get; set; }

		[JsonProperty(PropertyName = "private_gists")]
		public int PrivateGists { get; set; }

		[JsonProperty(PropertyName = "followers")]
		public int Followers { get; set; }

		[JsonProperty(PropertyName = "following")]
		public int Following { get; set; }

		[JsonProperty(PropertyName = "total_private_repos")]
		public int TotalPrivateRepos { get; set; }

		[JsonProperty(PropertyName = "owned_private_repos")]
		public int OwnedPrivateRepos { get; set; }

		[JsonProperty(PropertyName = "collaborators")]
		public int Collaborators { get; set; }

		[JsonProperty(PropertyName = "disk_usage")]
		public int DiskUsage { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "type")]
		public AccountType? Type { get; set; }

		[JsonProperty(PropertyName = "plan")]
		public Plan Plan { get; set; }
	}
}
