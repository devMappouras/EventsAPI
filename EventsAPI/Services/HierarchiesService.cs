using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;
using DataAccess.Models;

namespace EventsAPI.Services
{
    public class HierarchiesService : IHierarchiesService
    {
        private readonly IHierarchiesRepository _hierarchiesRepository;

        public HierarchiesService(IHierarchiesRepository HierarchiesRepository)
        {
            _hierarchiesRepository = HierarchiesRepository;
        }

        public async Task<IEnumerable<GenericIdAndNameModel>> GetHierarchies()
        {
            return await _hierarchiesRepository.GetHierarchies();
        }
    }
}