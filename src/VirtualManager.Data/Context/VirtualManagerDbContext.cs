using Microsoft.EntityFrameworkCore;
using System.Linq;
using VirtualManager.Business.Entities;

namespace VirtualManager.Data.Context
{
	public class VirtualManagerDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Provider> Providers { get; set; }
		public DbSet<Address> Addresses { get; set; }

		public VirtualManagerDbContext(DbContextOptions options)
			: base(options)
		{


		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var property in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetProperties()
					.Where(p => p.ClrType == typeof(string)))) property.Relational().ColumnName = "Varchar(100)";

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(VirtualManagerDbContext).Assembly);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

			base.OnModelCreating(modelBuilder);
		}
	}
}
