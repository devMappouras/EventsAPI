using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IHierarchiesRepository
{
    Task<IEnumerable<GenericIdAndNameModel>> GetHierarchies();
}