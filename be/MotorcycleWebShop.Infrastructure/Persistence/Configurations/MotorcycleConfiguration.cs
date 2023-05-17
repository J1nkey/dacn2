using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("Motorcycles");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(t => t.CubicCentimeters)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(t => t.HorsePower).IsRequired();
            builder.Property(t => t.Torque).IsRequired();
            builder.Property(t => t.ImagePath).IsRequired(false);

            builder.HasOne(s => s.MotorcycleType)
                .WithMany(d => d.Motorcycles)
                .HasForeignKey(fk => fk.MotorcycleTypeId);

            builder.HasOne(s => s.Manufacturer)
                .WithMany(d => d.Motorcycles)
                .HasForeignKey(fk => fk.ManufacturerId);
        }
    }
}
