namespace Github.Api.Models
{
	public class Plan
	{
		public virtual int Collaborators { get; set; }

		public virtual string Name { get; set; }

		public virtual int PrivateRepos { get; set; }

		public virtual long Space { get; set; }

		public override bool Equals(object obj)
		{
			if (obj is Plan)
			{
				var compareTo = (Plan)obj;

				if (compareTo.Equals(this.Name) && compareTo.Collaborators.Equals(this.Collaborators) &&
					compareTo.Space.Equals(this.Space) && compareTo.PrivateRepos.Equals(this.PrivateRepos))
				{
					return true;
				}

				return false;
			}

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return this.Name.GetHashCode() + this.Collaborators.GetHashCode();
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}