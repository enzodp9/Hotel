namespace Hotel.Services.DTOs
{
    public class GuestDTO
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Phone { get; set; }
    }

    public class CreateGuestDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Phone { get; set; }
    }
}
