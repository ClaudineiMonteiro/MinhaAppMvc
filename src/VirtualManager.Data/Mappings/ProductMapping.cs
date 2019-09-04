using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualManager.Business.Entities;

namespace VirtualManager.Data.Mappings
{
	public class ProductMapping : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Name)
				.IsRequired()
				.HasColumnType("Varchar(150)");

			builder.Property(p => p.Description)
				.IsRequired()
				.HasColumnType("Varchar(500)");

			builder.Property(p => p.Image)
				.IsRequired()
				.HasColumnType("Varchar(100)");

			builder.ToTable("Products");
		}
	}
}
