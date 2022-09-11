using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class CollectionsRepository : ICollectionsRepository
{
    private readonly ISqlDataAccess _db;

    public CollectionsRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetCollectionsResponse>> GetCollections() => await _db.LoadData<GetCollectionsResponse, dynamic>("Collections_GetAll", new { OrganiserId = 1} );

    public async Task<CollectionModel> GetCollectionById(int collectionId)
    {
        var results = await _db.LoadData<CollectionModel, dynamic>("Collections_Get", new { CollectionId = collectionId });
        return results.FirstOrDefault();
    }

    public Task InsertCollection(CollectionModel collection) => _db.SaveData("Collections_Insert", new { collection.Name });

    public Task UpdateCollection(CollectionModel collection) => _db.SaveData("Collections_Update", collection);

    public Task DeleteCollection(int collectionId) => _db.SaveData("Collections_Delete", new { CollectionId = collectionId });
}