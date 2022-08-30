using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using SectionsAPI.Services.Interfaces;
using DataAccess.Models;

namespace EventsAPI.Services
{
    public class SectionsService : ISectionsService
    {
        private readonly ISectionsRepository _SectionsRepository;

        public SectionsService(ISectionsRepository SectionsRepository)
        {
            _SectionsRepository = SectionsRepository;
        }

        public async Task<IEnumerable<GetSectionsResponse>> GetSections()
        {
            return await _SectionsRepository.GetSections();
        }

        public async Task<SectionModel> GetSectionById(int id)
        {
            return await _SectionsRepository.GetSectionById(id);
        }

        public async Task InsertSection(SectionModel Section)
        {

            await _SectionsRepository.InsertSection(Section);
        }

        public async Task UpdateSection(SectionModel Section)
        {
            await _SectionsRepository.UpdateSection(Section);
        }

        public async Task DeleteSection(int SectionsId)
        {
            await _SectionsRepository.DeleteSection(SectionsId);
        }
    }
}