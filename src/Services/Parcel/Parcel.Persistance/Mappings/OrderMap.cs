using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parcel.Domain.Entities;

namespace Parcel.Persistance.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.Weight)
                .IsRequired();

            builder.Property(o => o.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.DestinationAddress)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(o => o.Coortinates)
                .HasMaxLength(50);

            builder.Property(o => o.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(o => o.OrderInfo)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(o => o.UserId)
                .IsRequired();

            builder.Property(o => o.CurierId)
                .IsRequired(false);

            builder.Property(o => o.Status)
                .IsRequired();

            var order1 = new Order()
            {
                Id = Guid.NewGuid(),
                Title = "Grocery Essentials Pack (Vegetables, Dairy, Grains)",
                Weight = 1.2,
                TotalPrice = 70,
                DestinationAddress = "Baku, Sumgayiq 12 mkr",
                Coortinates = "Latitude: 51.507351-Longitude: -0.127758",
                PhoneNumber = "+994555555555",
                OrderInfo = "Test information",
                UserId = Guid.Parse("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"),
            };

            var order2 = new Order()
            {
                Id = Guid.NewGuid(),
                Title = "Air Jordan Retro Sneakers",
                Weight = 0.8,
                TotalPrice = 254,
                DestinationAddress = "Baku, Sumgayiq 12 mkr",
                Coortinates = "Latitude: 51.507351-Longitude: -0.127758",
                PhoneNumber = "+994555555555",
                OrderInfo = "Test information",
                UserId = Guid.Parse("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"),
            };

            var order3 = new Order()
            {
                Id = Guid.NewGuid(),
                Title = "Wireless Bluetooth Headphones",
                Weight = 0.1,
                TotalPrice = 110,
                DestinationAddress = "Baku, Sumgayiq 12 mkr",
                Coortinates = "Latitude: 51.507351-Longitude: -0.127758",
                PhoneNumber = "+994555555555",
                OrderInfo = "Test information",
                UserId = Guid.Parse("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"),
            };

            builder.HasData(order1, order2, order3);
        }
    }
}
