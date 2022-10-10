using DataAccess.Models;

namespace EventsAPI.Services.Interfaces;

public interface IHierarchiesService
{
    Task<IEnumerable<GenericIdAndNameModel>> GetHierarchies();
    Task<IEnumerable<GenericIdAndNameModel>> GetVenueHierarchies(int venueId);
}