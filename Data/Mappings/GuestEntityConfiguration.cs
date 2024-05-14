using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Mappings
{
    public class GuestEntityConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("guests");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(g => g.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(g => g.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(g => g.DateOfBirth)
                .HasColumnName("date_of_birth")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(g => g.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(g => g.Nationality)
                .HasColumnName("nationality")
                .HasColumnType("varchar(50)")
                .IsRequired();

        }
    }
}
