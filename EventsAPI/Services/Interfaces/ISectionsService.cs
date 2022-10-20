using DataAccess.Models.Responses;
using DataAccess.Models;

namespace SectionsAPI.Services.Interfaces
{
    public interface ISectionsService
    {
        Task InsertSection(SectionModel Section);

        Task UpdateSection(SectionModel Section);

        Task DeleteSection(int id);

        Task<SectionModel> GetSectionById(int id);

        Task<IEnumerable<GetSectionsResponse>> GetSections(int VenueId);
    }
}
