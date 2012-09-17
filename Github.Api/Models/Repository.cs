using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Github.Api.Models
{
	[DataContract]
	public class Repository
	{
		[JsonProperty(PropertyName = "clone_url")]
		public string CloneUrl { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public string CreatedAt { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "fork")]
		public bool Fork { get; set; }

		[JsonProperty(PropertyName = "forks")]
		public int Forks { get; set; }

		[JsonProperty(PropertyName = "full_name")]
		public string FullName { get; set; }
		
		[JsonProperty(PropertyName = "git_url")]
		public string GitUrl { get; set; }
		
		[JsonProperty(PropertyName = "homepage")]
		public string Homepage { get; set; }

		[JsonProperty(PropertyName = "html_url")]
		public string HtmlUrl { get; set; }

		[JsonProperty(PropertyName = "id")]
		public int ID { get; set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; set; }

		[JsonProperty(PropertyName = "master_branch")]
		public string MasterBranch { get; set; }

		[JsonProperty(PropertyName = "mirror_url")]
		public string MirrorUrl { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
		
		[JsonProperty(PropertyName = "open_issues")]
		public int OpenIssues { get; set; }

		[JsonProperty(PropertyName = "owner")]
		public User Owner { get; set; }

		[JsonProperty(PropertyName = "private")]
		public bool Private { get; set; }

		[JsonProperty(PropertyName = "pushed_at")]
		public string PushedAt { get; set; }
		
		[JsonProperty(PropertyName = "size")]
		public int Size { get; set; }

		[JsonProperty(PropertyName = "ssh_url")]
		public string SshUrl { get; set; }

		[JsonProperty(PropertyName = "svn_url")]
		public string SvnUrl { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public string UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "watchers")]
		public int Watchers { get; set; }
	}
}