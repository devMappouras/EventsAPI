using DataAccess.Models.Auth;

namespace DataAccess.Models.Responses;

public class GetVenuesAndCollections
{
    public GetVenuesAndCollections(List<GetVenuesResponse> venues, List<GetCollectionsResponse> collections)
    {
        Venues = venues;
        Collections = collections;
    }

    public List<GetVenuesResponse> Venues { get; set; }
    
    public List<GetCollectionsResponse> Collections { get; set; }
}