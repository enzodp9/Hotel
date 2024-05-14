using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Hotel.Data
{
    public class HotelDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"User ID = postgres; Password = 1234; Host = localhost; Port = 5432; Database = Hotel;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Mappings.UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new Mappings.GuestEntityConfiguration());
            modelBuilder.ApplyConfiguration(new Mappings.BookingEntityConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
