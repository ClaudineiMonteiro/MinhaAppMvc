using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vm.Business.Models;

namespace Vm.Data.Mappings
{
	public class AddressMapping : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.HasKey(k => k.Id);

			builder.Property(a => a.PublicPlace)
				.IsRequired()
				.HasColumnType("varchar(200)");

			builder.Property(a => a.Number)
				.IsRequired()
				.HasColumnType("varchar(10)");

			builder.Property(a => a.ZipCode)
				.IsRequired()
				.HasColumnType("varchar(8)");

			builder.Property(a => a.Complement)
				.IsRequired()
				.HasColumnType("varchar(20)");

			builder.Property(a => a.District)
				.IsRequired()
				.HasColumnType("varchar(100)");

			builder.Property(a => a.City)
				.IsRequired()
				.HasColumnType("varchar(100)");

			builder.Property(a => a.State)
				.IsRequired()
				.HasColumnType("varchar(2)");

			builder.ToTable("Adresses");
		}
	}
}
