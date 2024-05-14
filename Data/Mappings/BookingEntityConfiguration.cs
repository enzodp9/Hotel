using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Mappings
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("bookings");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(b => b.CheckIn)
                .HasColumnName("check_in")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(b => b.CheckOut)
                .HasColumnName("check_out")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(b => b.TotalPrice)
                .HasColumnName("total_price")
                .HasColumnType("double precision")
                .IsRequired();

            builder.Property(b => b.PaymentMethod)
                .HasColumnName("payment_method")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasOne(b => b.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GuestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
