using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vm.Business.Models;

namespace Vm.Data.Context
{
	public class MinhaAppMvcDbContext : DbContext
	{
		public MinhaAppMvcDbContext(DbContextOptions options) : base(options) {}

		public DbSet<Product> Products { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Provider> Providers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var property in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetProperties()
					.Where(p => p.ClrType == typeof(string))))
				property.Relational().ColumnType = "varchar(100)";


			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MinhaAppMvcDbContext).Assembly);

			foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationShip.DeleteBehavior = DeleteBehavior.ClientSetNull;

			base.OnModelCreating(modelBuilder);
		}
	}
}
