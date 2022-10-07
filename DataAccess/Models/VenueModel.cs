namespace DataAccess.Models
{
    public class VenueModel
    {
        public int? VenueId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Town { get; set; } = string.Empty;
        public string? CountryId { get; set; }
    }
}
