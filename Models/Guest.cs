namespace Hotel.Models
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Phone { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
