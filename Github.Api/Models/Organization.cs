using System;
using Newtonsoft.Json;

namespace Github.Api.Models
{
	public class Organization : Account
	{
		[JsonProperty(PropertyName = "billing_email")]
		public string BillingEmail { get; set; }
	}
}