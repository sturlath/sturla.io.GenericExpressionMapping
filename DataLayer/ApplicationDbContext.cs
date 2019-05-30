using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }
		public DbSet<Employee> Employees { get; set; }

		public DbSet<Car> Cars { get; set; }


		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>();
			modelBuilder.Entity<Employee>();
			modelBuilder.Entity<Car>();
		}
	}
}
