using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Github.Api.Models
{
	public class GitHubSshKey
	{
		public int Id { get; set; }

		public string Key { get; set; }

		public string Title { get; set; }

		public string Url { get; set; }

		public Tuple<string, string> GetKeyDataAndName()
		{
			Match match = new Regex(@"ssh-[rd]s[as] (\S+) ?(.*)$").Match(this.Key);
			if (!match.Success)
			{
				return null;
			}
			return new Tuple<string, string>(match.Groups[1].Value, match.Groups[2].Value);
		}
	}
}