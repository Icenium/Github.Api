using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Github.Api.Models
{
	public class SearchRepositoryResult
	{
		public IEnumerable<Repository> Items { get; set; }

		[JsonProperty(PropertyName = "total_count")]
		public int TotalCount { get; set; }
	}
}
