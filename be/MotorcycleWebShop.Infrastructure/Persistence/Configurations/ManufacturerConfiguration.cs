using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturers");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(150);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(250);
            builder.Property(t => t.From).IsRequired().HasMaxLength(150);
            builder.Property(t => t.ImagePath).IsRequired(false);
        }
    }
}
