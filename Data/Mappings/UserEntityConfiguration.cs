using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Mappings
{
    public class UserEntityConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(u => u.Username)
                .HasColumnName("username")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(u => u.Role)
                .HasColumnName("role")
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
