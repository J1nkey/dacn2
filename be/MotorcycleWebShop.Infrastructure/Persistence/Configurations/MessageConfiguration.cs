using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.MessageValue).IsRequired();

            builder.HasOne(s => s.Sender)
                .WithMany(d => d.MessagesToUsers)
                .HasForeignKey(fk => fk.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(s => s.Receiver)
                .WithMany(d => d.MessagesFromUsers)
                .HasForeignKey(fk => fk.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
