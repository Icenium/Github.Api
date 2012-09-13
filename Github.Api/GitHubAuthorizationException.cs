using System;

namespace Github.Api
{
	[Serializable]
	public class GitHubAuthorizationException : Exception
	{
		public GitHubAuthorizationException()
		{
		}

		public GitHubAuthorizationException(string message) : base(message)
		{
		}

		public GitHubAuthorizationException(string message, Exception inner) : base(message, inner)
		{
		}

		protected GitHubAuthorizationException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
	}
}