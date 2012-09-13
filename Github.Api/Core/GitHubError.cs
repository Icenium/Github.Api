using System;
using System.Linq;

namespace Github.Api.Core
{
	public class GitHubError
	{
		public string Resource { get; set; }
		public string Message { get; set; }
		public string Code { get; set; }
		public string Field { get; set; }
	}
}
