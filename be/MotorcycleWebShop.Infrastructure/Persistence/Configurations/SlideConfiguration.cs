using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Entities;
namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired(false).HasMaxLength(150);
            builder.Property(x => x.ImagePath).IsRequired(false);
            builder.Property(x => x.ImagePath).IsRequired();
            builder.Property(x => x.SortOrder).IsRequired();
        }
    }
}
