namespace EventsAPI.Models.Entities
{
    public class EventEntity
    {
        public int EventId { get; set; }
        public string? EventTitle { get; set; }
        public string? EventDescription { get; set; }
        public DateTimeOffset? EventDateTime { get; set; }
        public string? BannerImage { get; set; }
        public int? VenueId { get; set; }
        public int? CollectionId { get; set; }
        public int? OrganiserId { get; set; }
    }
}
