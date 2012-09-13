using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Github.Api.Core
{
	public class CreateRepositoryInfo
	{
		private readonly string description;

		private readonly string homepage;

		private readonly bool isPrivate;

		private readonly bool hasIssues;

		private readonly bool hasWiki;

		private readonly bool hasDownloads;

		private readonly string name;

		public CreateRepositoryInfo(string name, string description, string homepage,
			bool isPrivate = false, bool hasIssues = true, bool hasWiki = true, bool hasDownloads = true)
		{
			this.name = name;
			this.description = description;
			this.homepage = homepage;
			this.isPrivate = isPrivate;
			this.hasIssues = hasIssues;
			this.hasWiki = hasWiki;
			this.hasDownloads = hasDownloads;
		}

		[JsonProperty(PropertyName = "name")]
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		[JsonProperty(PropertyName = "description")]
		public string Description
		{
			get
			{
				return description;
			}
		}

		[JsonProperty(PropertyName = "homepage")]
		public string Homepage
		{
			get
			{
				return homepage;
			}
		}

		[JsonProperty(PropertyName = "private")]
		public bool IsPrivate
		{
			get
			{
				return isPrivate;
			}
		}

		[JsonProperty(PropertyName = "has_issues")]
		public bool HasIssues
		{
			get
			{
				return hasIssues;
			}
		}

		[JsonProperty(PropertyName = "has_wiki")]
		public bool HasWiki
		{
			get
			{
				return hasWiki;
			}
		}

		[JsonProperty(PropertyName = "has_downloads")]
		public bool HasDownloads
		{
			get
			{
				return hasDownloads;
			}
		}
	}
}