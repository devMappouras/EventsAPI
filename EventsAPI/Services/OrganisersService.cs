using DataAccess.Models.Responses;
using EventsAPI.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using DataAccess.Models;

namespace EventsAPI.Services;

public class OrganisersService : IOrganisersService
{
    private readonly IOrganisersRepository _organisersRepository;

    public OrganisersService(IOrganisersRepository organisersRepository)
    {
        _organisersRepository = organisersRepository;
    }

    public async Task<IEnumerable<GetOrganisersResponse>> GetOrganisers()
    {
        return await _organisersRepository.GetOrganisers();
    }

    public async Task<OrganiserModel> GetOrganiserById(int id)
    {
        return await _organisersRepository.GetOrganiserById(id);
    }

    public async Task InsertOrganiser(OrganiserModel Organiser)
    {
        await _organisersRepository.InsertOrganiser(Organiser);
    }

    public async Task UpdateOrganiser(OrganiserModel Organiser)
    {
        await _organisersRepository.UpdateOrganiser(Organiser);
    }

    public async Task DeleteOrganiser(int OrganisersId)
    {
        await _organisersRepository.DeleteOrganiser(OrganisersId);
    }
}