using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");
            builder.HasKey(x => x.Id);

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Dob).IsRequired();
            builder.Property(e => e.IdentificationNumber).IsRequired().HasMaxLength(12);
            builder.Property(e => e.Avatar).IsRequired(false);
        }
    }
}
