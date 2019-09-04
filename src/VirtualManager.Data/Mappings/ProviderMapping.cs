using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualManager.Business.Entities;

namespace VirtualManager.Data.Mappings
{
	public class ProviderMapping : IEntityTypeConfiguration<Provider>
	{
		public void Configure(EntityTypeBuilder<Provider> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Name)
				.IsRequired()
				.HasColumnType("Varchar(150)");

			builder.Property(p => p.Document)
				.IsRequired()
				.HasColumnType("Varchar(14)");

			builder.HasOne(f => f.Address)
				.WithOne(a => a.Provider);

			builder.HasMany(f => f.Products)
				.WithOne(p => p.Provider)
				.HasForeignKey(p => p.Provider);

			builder.ToTable("Providers");
		}
	}
}
