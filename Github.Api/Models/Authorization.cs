using System;
using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class Authorization
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "token")]
		public string Token { get; set; }

		[JsonProperty(PropertyName = "note")]
		public string Note { get; set; }

		[JsonProperty(PropertyName = "note_url")]
		public string NoteUrl { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public string CreatedAt { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public string UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "scopes")]
		public string[] Scopes { get; set; }

		[JsonProperty(PropertyName = "app")]
		public Application Application { get; set; }
	}
}