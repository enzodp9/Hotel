namespace Hotel.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public double? TotalPrice { get; set; }
        public string? PaymentMethod { get; set; }

        public Guid? GuestId { get; set; }
        public Guest? Guest { get; set; }   
    }
}
