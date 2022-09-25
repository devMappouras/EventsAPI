using DataAccess.Models.Auth;

namespace DataAccess.Models.Responses;

public class GetVenuesAndCollections
{
    public GetVenuesAndCollections(List<VenueModel> venues, List<GetCollectionsResponse> collections)
    {
        Venues = venues;
        Collections = collections;
    }

    public List<VenueModel> Venues { get; set; }
    
    public List<GetCollectionsResponse> Collections { get; set; }
}