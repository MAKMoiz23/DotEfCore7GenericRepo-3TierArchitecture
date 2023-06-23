using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
	public class DataContext : DbContext
	{
		public DataContext()
		{
		}

		public DataContext(DbContextOptions options) : base(options)
		{
		}

		#region Dbset
		public DbSet<Customer> Customers { get; set; }
		#endregion

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options.UseSqlServer("Data Source=sql5053.site4now.net;Initial Catalog=db_a74425_premiumpos;Persist Security Info=True;User ID=db_a74425_premiumpos_admin;Password=PPpp1212#;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
