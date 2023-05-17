using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Title).IsRequired().HasMaxLength(250);
            builder.Property(t => t.Details).IsRequired();
            builder.Property(t => t.CubicCentimeters).IsRequired();
            builder.Property(t => t.HorsePower).IsRequired();
            builder.Property(t => t.Torque).IsRequired();
            builder.Property(t => t.KilometersConsumption).IsRequired();

            builder.HasOne(s => s.Motorcycle)
                .WithMany(d => d.Posts)
                .HasForeignKey(k => k.MotorcycleId);

            builder.HasOne(s => s.Provider)
                .WithMany(d => d.Posts)
                .HasForeignKey(k => k.ProviderId);
        }
    }
}
