using System;
using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class Repository
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "full_name")]
		public string FullName { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "private")]
		public bool Private { get; set; }

		[JsonProperty(PropertyName = "fork")]
		public bool Fork { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "html_url")]
		public string HtmlUrl { get; set; }

		[JsonProperty(PropertyName = "clone_url")]
		public string CloneUrl { get; set; }

		[JsonProperty(PropertyName = "git_url")]
		public string GitUrl { get; set; }

		[JsonProperty(PropertyName = "ssh_url")]
		public string SshUrl { get; set; }

		[JsonProperty(PropertyName = "svn_url")]
		public string SvnUrl { get; set; }

		[JsonProperty(PropertyName = "mirror_url")]
		public string MirrorUrl { get; set; }

		[JsonProperty(PropertyName = "homepage")]
		public string HomePage { get; set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; set; }

		[JsonProperty(PropertyName = "forks_count")]
		public int ForksCount { get; set; }

		[JsonProperty(PropertyName = "stargazers_count")]
		public int StargazersCount { get; set; }

		[JsonProperty(PropertyName = "watchers_count")]
		public int WatchersCount { get; set; }

		[JsonProperty(PropertyName = "size")]
		public long Size { get; set; }

		[JsonProperty(PropertyName = "master_branch")]
		public string MasterBranch { get; set; }

		[JsonProperty(PropertyName = "open_issues_count")]
		public int OpenIssuesCount { get; set; }

		[JsonProperty(PropertyName = "pushed_at")]
		public DateTimeOffset PushedAt { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTimeOffset UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "owner")]
		public User Owner { get; set; }

		[JsonProperty(PropertyName = "organization")]
		public Organization Organization { get; set; }

		[JsonProperty(PropertyName = "parent")]
		public Repository Parent { get; set; }

		[JsonProperty(PropertyName = "source")]
		public Repository Source { get; set; }
	}
}