using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Github.Api.Models
{
	[DataContract]
	public class Repository
	{
		[DataMember(Name = "url")]
		public string Url { get; set; }

		[DataMember(Name = "html_url")]
		public string HtmlUrl { get; set; }

		[DataMember(Name = "clone_url")]
		public string CloneUrl { get; set; }

		[DataMember(Name = "git_url")]
		public string GitUrl { get; set; }
		
		[DataMember(Name = "ssh_url")]
		public string SshUrl { get; set; }

		[DataMember(Name = "svn_url")]
		public string SvnUrl { get; set; }

		[DataMember(Name = "mirror_url")]
		public string MirrorUrl { get; set; }

		[DataMember(Name = "id")]
		public int ID { get; set; }

		[DataMember(Name = "owner")]
		public User Owner { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		[DataMember(Name = "full_name")]
		public string FullName { get; set; }
		
		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "homepage")]
		public string Homepage { get; set; }

		[DataMember(Name = "language")]
		public string Language { get; set; }

		[DataMember(Name = "private")]
		public bool Private { get; set; }

		[DataMember(Name = "fork")]
		public bool Fork { get; set; }

		[DataMember(Name = "forks")]
		public int Forks { get; set; }

		[DataMember(Name = "watchers")]
		public int Watchers { get; set; }

		[DataMember(Name = "size")]
		public int Size { get; set; }

		[DataMember(Name = "master_branch")]
		public string MasterBranch { get; set; }

		[DataMember(Name = "open_issues")]
		public int OpenIssues { get; set; }

		[DataMember(Name = "pushed_at")]
		public string PushedAt { get; set; }
		
		[DataMember(Name = "created_at")]
		public string CreatedAt { get; set; }

		[DataMember(Name = "updated_at")]
		public string UpdatedAt { get; set; }
	}
}