using System;
using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class User : Account
	{
		[JsonProperty(PropertyName = "gravatar_id")]
		public string GravatarId { get; set; }

		[JsonProperty(PropertyName = "followers_url")]
		public string FollowersUrl { get; set; }

		[JsonProperty(PropertyName = "following_url")]
		public string FollowingUrl { get; set; }

		[JsonProperty(PropertyName = "gists_url")]
		public string GistsUrl { get; set; }

		[JsonProperty(PropertyName = "starred_url")]
		public string StarredUrl { get; set; }

		[JsonProperty(PropertyName = "subscriptions_url")]
		public string SubscriptionsUrl { get; set; }

		[JsonProperty(PropertyName = "organizations_url")]
		public string OrganizationsUrl { get; set; }

		[JsonProperty(PropertyName = "repos_url")]
		public string ReposUrl { get; set; }

		[JsonProperty(PropertyName = "events_url")]
		public string EventsUrl { get; set; }

		[JsonProperty(PropertyName = "received_events_url")]
		public string ReceivedEventsUrl { get; set; }

		[JsonProperty(PropertyName = "site_admin")]
		public bool SiteAdmin { get; set; }

		[JsonProperty(PropertyName = "hireable")]
		public bool? Hireable { get; set; }

		[JsonProperty(PropertyName = "bio")]
		public string Bio { get; set; }
	}
}