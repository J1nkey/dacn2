using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(250);
            builder.Property(t => t.Address).IsRequired().HasMaxLength(250);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(250);
            builder.Property(t => t.PhoneNumber).IsRequired().HasMaxLength(20);

            builder.HasOne(s => s.ApplicationUser)
                .WithOne(d => d.Provider)
                .HasForeignKey<Provider>(k => k.ApplicationUserId);
        }

    }
}
