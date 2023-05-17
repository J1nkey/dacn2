using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    public class MotorcycleTypeConfiguration : IEntityTypeConfiguration<MotorcycleType>
    {
        public void Configure(EntityTypeBuilder<MotorcycleType> builder)
        {
            builder.ToTable("MotorcycleType");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.TypeName).IsRequired();
            builder.Property(t => t.ImagePath).IsRequired(false);
        }
    }
}
