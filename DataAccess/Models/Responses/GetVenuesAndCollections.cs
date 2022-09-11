using DataAccess.Models.Auth;

namespace DataAccess.Models.Responses;

public class GetVenuesAndCollections
{
    public List<GenericIdAndNameModel> Venues { get; set; }
    
    public List<GenericIdAndNameModel> Collections { get; set; }
}