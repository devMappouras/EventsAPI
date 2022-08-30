using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class SectionsRepository : ISectionsRepository
{
    private readonly ISqlDataAccess _db;

    public SectionsRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetSectionsResponse>> GetSections() => await _db.LoadData<GetSectionsResponse, dynamic>("Sections_GetAll", new { });

    public async Task<SectionModel?> GetSectionById(int SectionId)
    {
        var results = await _db.LoadData<SectionModel, dynamic>("Sections_Get", new { SectionId });
        return results.FirstOrDefault();
    }

    public Task InsertSection(SectionModel Section) => _db.SaveData("Sections_Insert",
        new
        {
            Section.Name,
            Section.HierarchyId,
            Section.VenueId
        });

    public Task UpdateSection(SectionModel Section) => _db.SaveData("Sections_Update", Section);

    public Task DeleteSection(int SectionId) => _db.SaveData("Sections_Delete", new { SectionId });
}
