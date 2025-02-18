using System.ComponentModel.DataAnnotations;

namespace ProjectManagerM_LGroupAB.Models
{
	public class Project
	{
		
		public int Id { get; set; }
		[Required]
		public string ProjectNumber { get; set; } = string.Empty;
		[Required]
		public string ProjectName { get; set; } = string.Empty;
		
		public DateTime StartDate { get; set; }
		
		public DateTime EndDate { get; set; }
		[Required]
		public string Status { get; set; } = string.Empty;
		
		public decimal TotalPrice { get; set; }

		//Relation till Customer
		public int CustomerId { get; set; }

		public Customer? Customer { get; set; } 


	}
}
