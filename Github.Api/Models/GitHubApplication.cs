using System;
using System.Linq;
using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class GitHubApplication
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }
	}
}