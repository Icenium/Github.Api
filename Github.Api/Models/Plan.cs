using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class Plan
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "space")]
		public long Space { get; set; }

		[JsonProperty(PropertyName = "collaborators")]
		public int Collaborators { get; set; }

		[JsonProperty(PropertyName = "private_repos")]
		public int PrivateRepos { get; set; }
	}
}