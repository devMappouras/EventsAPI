using DataAccess.Models.Responses;
using DataAccess.Models;
using DataAccess.Models.Auth;

namespace EventsAPI.Services.Interfaces;

public interface IOrganisersService
{
    Task DeleteOrganiser(int OrganisersId);
    Task<OrganiserModel> GetOrganiserById(int id);
    Task<IEnumerable<GetOrganisersResponse>> GetOrganisers();
    Task RegisterOrganiser(OrganiserModel Organiser);
    Task<LoginOrganiserResponse> LoginOrganiser(UserDto user);
    Task UpdateOrganiser(OrganiserModel Organiser);
}