using DataAccess.Models.Responses;
using DataAccess.Models;

namespace EventsAPI.Services;

public interface IOrganisersRepository
{
    Task DeleteOrganiser(int OrganisersId);
    Task<OrganiserModel> GetOrganiserById(int id);
    Task<IEnumerable<GetOrganisersResponse>> GetOrganisers();
    Task InsertOrganiser(OrganiserModel Organiser);
    Task UpdateOrganiser(OrganiserModel Organiser);
}