using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
					entry.Property("LastUpdatedDate").IsModified = false;
				}

				if (entry.State == EntityState.Modified)
				{
					entry.Property("RegistrationDate").IsModified = false;
					entry.Property("LastUpdatedDate").CurrentValue = DateTime.Now;
					
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
