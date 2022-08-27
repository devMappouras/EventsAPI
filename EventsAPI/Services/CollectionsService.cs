using DataAccess.Models.Responses;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services.Interfaces;

namespace EventsAPI.Services;

public class CollectionsService : ICollectionsService
{
    private readonly ICollectionsRepository _collectionsRepository;

    public CollectionsService(ICollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }
    
    public async Task InsertCollection(CollectionModel collection)
    {
        await _collectionsRepository.InsertCollection(collection);
    }

    public async Task UpdateCollection(CollectionModel collection)
    {
        await _collectionsRepository.UpdateCollection(collection);
    }

    public async Task DeleteCollection(int collectionId)
    {
        await _collectionsRepository.DeleteCollection(collectionId);
    }

    public async Task<CollectionModel> GetCollectionById(int collectionId)
    {
       return await _collectionsRepository.GetCollectionById(collectionId);
    }

    public async Task<IEnumerable<GetCollectionsResponse>> GetCollections()
    {
        return await _collectionsRepository.GetCollections();
    }
}