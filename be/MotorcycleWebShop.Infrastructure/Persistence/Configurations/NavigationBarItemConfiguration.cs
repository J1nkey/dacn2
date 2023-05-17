using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    public class NavigationBarItemConfiguration : IEntityTypeConfiguration<NavigationBarItem>
    {
        public void Configure(EntityTypeBuilder<NavigationBarItem> builder)
        {
            builder.ToTable("NavigationBarItems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Url).IsRequired(false);
            builder.Property(x => x.IsParentItem).IsRequired();
            builder.Property(x => x.ParentId).IsRequired(false);
        }
    }
}
