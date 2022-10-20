using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface ISectionsRepository
{
    Task DeleteSection(int id);
    Task<SectionModel?> GetSectionById(int id);
    Task<IEnumerable<GetSectionsResponse>> GetSections(int VenueId);
    Task InsertSection(SectionModel Section);
    Task UpdateSection(SectionModel Section);
}