using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class SshKey
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "key")]
		public string Key { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }
	}
}