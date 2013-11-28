using Newtonsoft.Json;

namespace Github.Api.Core
{
	public class CreateRepositoryInfo
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; private set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "homepage")]
		public string HomePage { get; set; }

		[JsonProperty(PropertyName = "private")]
		public bool IsPrivate { get; set; }

		[JsonProperty(PropertyName = "has_issues")]
		public bool HasIssues { get; set; }

		[JsonProperty(PropertyName = "has_wiki")]
		public bool HasWiki { get; set; }

		[JsonProperty(PropertyName = "has_downloads")]
		public bool HasDownloads { get; set; }

		[JsonProperty(PropertyName = "team_id")]
		public int TeamId { get; set; }

		[JsonProperty(PropertyName = "auto_init")]
		public bool AutoInit { get; set; }

		[JsonProperty(PropertyName = "gitignore_template")]
		public string GitIgnoreTemplate { get; set; }

		public CreateRepositoryInfo(string name)
		{
			this.Name = name;
			this.HasIssues = true;
			this.HasWiki = true;
			this.HasDownloads = true;
		}
	}
}