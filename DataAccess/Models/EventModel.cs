namespace DataAccess.Models
{
    public class EventModel
    {
        public int? EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public DateTimeOffset? EventDateTime { get; set; }
        public string? BannerImage { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public int? VenueId { get; set; }
        public int? CollectionId { get; set; }
        public int? OrganiserId { get; set; }
    }
}
