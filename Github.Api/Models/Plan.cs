namespace Github.Api.Models
{
	public class Plan
	{
		public virtual string Name { get; set; }

		public virtual int Collaborators { get; set; }

		public virtual long Space { get; set; }

		public virtual int PrivateRepos { get; set; }

		public override bool Equals(object obj)
		{
			if (obj is Plan)
			{
				var compareTo = (Plan)obj;

				if (compareTo.Equals(Name) && compareTo.Collaborators.Equals(Collaborators) &&
					compareTo.Space.Equals(Space) && compareTo.PrivateRepos.Equals(PrivateRepos))
				{
					return true;
				}

				return false;
			}

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode() + Collaborators.GetHashCode();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}