using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualManager.Business.Entities;

namespace VirtualManager.Data.Mappings
{
	public class AddressMapping : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.PublicPlace)
				.IsRequired()
				.HasColumnType("Varchar(200)");

			builder.Property(p => p.Number)
				.IsRequired()
				.HasColumnType("Varchar(10)");

			builder.Property(p => p.ZipCode)
				.IsRequired()
				.HasColumnType("Varchar(8)");

			builder.Property(p => p.Complement)
				.IsRequired()
				.HasColumnType("Varchar(15)");

			builder.Property(p => p.Condado)
				.IsRequired()
				.HasColumnType("Varchar(100)");

			builder.Property(p => p.City)
				.IsRequired()
				.HasColumnType("Varchar(100)");

			builder.Property(p => p.State)
				.IsRequired()
				.HasColumnType("Varchar(2)");

			builder.ToTable("Addresses");
		}
	}
}
