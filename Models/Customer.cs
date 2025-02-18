namespace ProjectManagerM_LGroupAB.Models
{
	public class Customer
	{
		public int Id { get; set; }


		// Relation till Projects
		public ICollection<Project> Projects { get; set; }

	}
}
