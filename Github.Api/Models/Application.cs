using System;
using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class Application
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }
	}
}