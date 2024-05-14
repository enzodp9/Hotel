namespace Hotel.Services.DTOs
{
    public class BookingDTO
    {
        public string? Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public double? TotalPrice { get; set; }
        public string? PaymentMethod { get; set; }
        public string? GuestId { get; set; }
    }

    public class CreateBookingDTO
    {
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public double? TotalPrice { get; set; }
        public string? PaymentMethod { get; set; }
        public string? GuestId { get; set; }
    }
}
