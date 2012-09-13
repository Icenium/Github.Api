namespace Github.Api.Models
{
	public class User : UpdateableUser
	{
		//public, authentication not required
		public virtual int Id { get; set; }
		public virtual string Login { get; set; }
		public virtual int FollowingCount { get; set; }
		public virtual int FollowersCount { get; set; }
		public virtual int PublicGistCount { get; set; }
		public virtual int PublicRepoCount { get; set; }

		//private, authentication required
		public virtual int TotalPrivateRepoCount { get; set; }
		public virtual int Collaborators { get; set; }
		public virtual long DiskUsage { get; set; }
		public virtual int OwnedPrivateRepoCount { get; set; }
		public virtual int PrivateGistCount { get; set; }
		public virtual Plan Plan { get; set; }

		public override bool Equals(object obj)
		{
			if (obj is User)
			{
				var compareTo = (User)obj;

				return compareTo.Id.Equals(Id) && compareTo.Name.Equals(Name) && compareTo.Email.Equals(Email);
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
