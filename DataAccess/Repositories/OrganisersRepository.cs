using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class OrganisersRepository : IOrganisersRepository
{
    private readonly ISqlDataAccess _db;

    public OrganisersRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetOrganisersResponse>> GetOrganisers() => await _db.LoadData<GetOrganisersResponse, dynamic>("Organisers_GetAll", new { });

    public async Task<OrganiserModel?> GetOrganiserById(int OrganiserId)
    {
        var results = await _db.LoadData<OrganiserModel, dynamic>("Organisers_Get", new { OrganiserId = OrganiserId });
        return results.FirstOrDefault();
    }

    public Task RegisterOrganiser(OrganiserModel Organiser) => _db.SaveData("Organisers_Insert",
        new
        {
            Organiser.Username,
            Organiser.Password,
            Organiser.PasswordSalt,
            Organiser.Name,
            Organiser.Location,
            Organiser.Logo,
            RoleId = 1
        });

    public async Task<OrganiserModel> GetOrganiserInfoByUsername(string Username)
    {
        var results = await _db.LoadData<OrganiserModel, dynamic>("Organisers_GetInfoForValidation", new { Username });
        return results.FirstOrDefault();
    }


    public Task UpdateOrganiser(OrganiserModel Organiser) => _db.SaveData("Organisers_Update", Organiser);

    public Task DeleteOrganiser(int OrganiserId) => _db.SaveData("Organisers_Delete", new { OrganiserId });
}
