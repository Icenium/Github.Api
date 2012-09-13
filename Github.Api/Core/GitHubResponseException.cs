using System;

namespace Github.Api.Core
{
	[Serializable]
	public class GitHubResponseException : Exception
	{
		public GitHubResponseException()
		{
		}

		public GitHubResponseException(string message) : base(message)
		{
		}

		public GitHubResponseException(string message, Exception inner) : base(message, inner)
		{
		}

		protected GitHubResponseException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}

		public dynamic Response { get; set; }
	}
}
