using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Github.Api.Core
{
	public class CreateRepositoryInfo
	{
		[JsonProperty(PropertyName = "description")]
		public string Description { get; private set; }

		[JsonProperty(PropertyName = "has_downloads")]
		public bool HasDownloads { get; private set; }

		[JsonProperty(PropertyName = "has_issues")]
		public bool HasIssues { get; private set; }

		[JsonProperty(PropertyName = "has_wiki")]
		public bool HasWiki { get; private set; }

		[JsonProperty(PropertyName = "homepage")]
		public string Homepage { get; private set; }

		[JsonProperty(PropertyName = "private")]
		public bool IsPrivate { get; private set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; private set; }

		public CreateRepositoryInfo(string name, string description, string homepage,
			bool isPrivate = false, bool hasIssues = true, bool hasWiki = true, bool hasDownloads = true)
		{
			this.Name = name;
			this.Description = description;
			this.Homepage = homepage;
			this.IsPrivate = isPrivate;
			this.HasIssues = hasIssues;
			this.HasWiki = hasWiki;
			this.HasDownloads = hasDownloads;
		}
	}
}