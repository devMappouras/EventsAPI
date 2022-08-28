namespace DataAccess.Models.Responses;

public class GetOrganisersResponse
{
    public int EventId { get; set; }
    public string? EventTitle { get; set; }
    public string? EventDescription { get; set; }
    public DateTimeOffset? EventDateTime { get; set; }
    public string? BannerImage { get; set; }
    public int? VenueId { get; set; }
    public string? VenueName { get; set; }
    public int? CollectionId { get; set; }
    public string? CollectionName { get; set; }
}
