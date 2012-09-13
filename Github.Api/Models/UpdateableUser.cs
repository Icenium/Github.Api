namespace Github.Api.Models
{
	public class UpdateableUser
	{
		public virtual string Name { get; set; }
		public virtual string Email { get; set; }
		public virtual string Blog { get; set; }
		public virtual string Company { get; set; }
		public virtual string Location { get; set; }
		public virtual bool Hireable { get; set; }
		public virtual string Bio { get; set; }
	}
}