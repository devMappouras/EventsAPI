using DataAccess.Models.Responses;
using DataAccess.Models;

namespace EventsAPI.Services.Interfaces;

public interface IOrganisersService
{
    Task DeleteOrganiser(int OrganisersId);
    Task<OrganiserModel> GetOrganiserById(int id);
    Task<IEnumerable<GetOrganisersResponse>> GetOrganisers();
    Task InsertOrganiser(OrganiserModel Organiser);
    Task UpdateOrganiser(OrganiserModel Organiser);
}