namespace DataAccess.Models.Responses;

public class GetEventsResponse
{
    public int EventId { get; set; }
    public string? EventTitle { get; set; } = string.Empty;
    public string? EventDescription { get; set; } = string.Empty;
    public DateTimeOffset? EventDateTime { get; set; }
    public string? BannerImage { get; set; } = string.Empty;
    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; } = string.Empty;
    public int? VenueId { get; set; }
    public string? VenueName { get; set; } = string.Empty;
    public int? CollectionId { get; set; }
    public string? CollectionName { get; set; } = string.Empty;
}
