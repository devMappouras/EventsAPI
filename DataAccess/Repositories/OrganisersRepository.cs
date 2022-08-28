using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

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

    public Task InsertOrganiser(OrganiserModel Organiser) => _db.SaveData("Organisers_Insert",
        new
        {
            Organiser.Name,
            Organiser.Location,
            Organiser.Logo
        });

    public Task UpdateOrganiser(OrganiserModel Organiser) => _db.SaveData("Organisers_Update", Organiser);

    public Task DeleteOrganiser(int OrganiserId) => _db.SaveData("Organisers_Delete", new { OrganiserId = OrganiserId });
}
