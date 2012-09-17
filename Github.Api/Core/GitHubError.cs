using System;
using System.Linq;

namespace Github.Api.Core
{
	public class GitHubError
	{
		public string Code { get; set; }

		public string Field { get; set; }

		public string Message { get; set; }

		public string Resource { get; set; }
	}
}