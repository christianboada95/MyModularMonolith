using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMonolith.Notifications.Domain.Entities;

namespace MyMonolith.Notifications.Infrastructure.Data.Config
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Recipient)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(p => p.Message)
                .HasMaxLength(500)
                .IsRequired(false);

            //builder.HasData(new ProductSeeder());
        }
    }
}
