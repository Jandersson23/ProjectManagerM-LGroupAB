using Microsoft.EntityFrameworkCore;
using ProjectManagerM_LGroupAB.Models;

namespace ProjectManagerM_LGroupAB.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Project> Projects { get; set; }
		public DbSet<Customer> Customers { get; set; }
	}
}
