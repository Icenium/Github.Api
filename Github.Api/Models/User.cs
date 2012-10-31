namespace Github.Api.Models
{
	public class User : UpdateableUser
	{
		//public, authentication not required
		public string Id { get; set; }
		public string Login { get; set; }
		public int FollowingCount { get; set; }
		public int FollowersCount { get; set; }
		public int PublicGistCount { get; set; }
		public int PublicRepoCount { get; set; }

		//private, authentication required
		public int TotalPrivateRepoCount { get; set; }
		public int Collaborators { get; set; }
		public long DiskUsage { get; set; }
		public int OwnedPrivateRepoCount { get; set; }
		public int PrivateGistCount { get; set; }
		public Plan Plan { get; set; }

		public override bool Equals(object obj)
		{
			if (obj is User)
			{
				var compareTo = (User)obj;

				return compareTo.Id.Equals(Id) && compareTo.Login.Equals(Login);
			}

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode() + Login.GetHashCode();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
