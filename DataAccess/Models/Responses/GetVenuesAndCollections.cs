using DataAccess.Models.Auth;

namespace DataAccess.Models.Responses;

public class GetVenuesAndCollections
{
    public GetVenuesAndCollections(List<GetVenuesResponse> venues, List<GetCollectionsResponse> collections, List<GetCategoriesResponse> categories)
    {
        Venues = venues;
        Collections = collections;
        Categories = categories;
    }

    public List<GetVenuesResponse> Venues { get; set; }
    
    public List<GetCollectionsResponse> Collections { get; set; }
    public List<GetCategoriesResponse> Categories { get; set; }
}