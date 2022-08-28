using DataAccess.Models.Responses;
using DataAccess.Models;

namespace EventsAPI.Services.Interfaces;

public interface ICollectionsService
{
    Task InsertCollection(CollectionModel Collection);

    Task UpdateCollection(CollectionModel Collection);

    Task DeleteCollection(int id);

    Task<CollectionModel> GetCollectionById(int id);

    Task<IEnumerable<GetCollectionsResponse>> GetCollections();
}