namespace DataAccess.Models.Responses
{
    public class GetCustomerTicketsResponse
    {
        public int? TicketId { get; set; }
        public int? EventId { get; set; }
        public string EventTitle { get; set; } = String.Empty;
        public DateTimeOffset? EventDateTime { get; set; }
        public int? VenueId { get; set; }
        public string VenueName { get; set; } = String.Empty;
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; } = String.Empty;
        public string HierarchyName { get; set; } = String.Empty;
        public decimal? Price { get; set; }
        public string SectionName { get; set; } = String.Empty;
    }
}
