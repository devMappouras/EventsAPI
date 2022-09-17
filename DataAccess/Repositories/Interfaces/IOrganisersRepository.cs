using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface IOrganisersRepository
{
    Task DeleteOrganiser(int id);
    Task<OrganiserModel?> GetOrganiserById(int id);
    Task<IEnumerable<GetOrganisersResponse>> GetOrganisers();
    Task RegisterOrganiser(OrganiserModel Organiser);
    Task UpdateOrganiser(OrganiserModel Organiser);
    Task<OrganiserModel> GetOrganiserInfoByUsername(string username);
}