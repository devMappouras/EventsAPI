using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface ICollectionsRepository
{
    Task<IEnumerable<GetCollectionsResponse>> GetCollections();
    Task<CollectionModel> GetCollectionById(int collectionId);
    Task InsertCollection(CollectionModel collection);
    Task UpdateCollection(CollectionModel collection);
    Task DeleteCollection(int collectionId);
}