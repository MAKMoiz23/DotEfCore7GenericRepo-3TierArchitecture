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
				options.UseSqlServer("Data Source=.;Initial Catalog=GoMobiShop;TrustServerCertificate=True;Integrated Security=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
