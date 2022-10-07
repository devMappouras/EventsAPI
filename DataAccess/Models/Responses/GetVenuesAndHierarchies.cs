using DataAccess.Models.Auth;

namespace DataAccess.Models.Responses;

public class GetVenuesAndHierarchies
{
    public GetVenuesAndHierarchies(List<GetVenuesResponse> venues, List<GenericIdAndNameModel> hierarchies)
    {
        Venues = venues;
        Hierarchies = hierarchies;
    }

    public List<GetVenuesResponse> Venues { get; set; }
    
    public List<GenericIdAndNameModel> Hierarchies { get; set; }
}