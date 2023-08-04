using BooksApi.Models;
using MongoDB.Driver;

namespace BooksApi.Repositories;

public interface IBookRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<BookDetails>> GetAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BookDetails> GetAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Guid> UpsertAsync(BookDetails request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<BookDetails> _collection;
    
    public const string CollectionName = "Books";
    
    public BookRepository(IMongoCollection<BookDetails> collection)
    {
        _collection = collection;
    }
    
    public Task<List<BookDetails>> GetAsync(CancellationToken cancellationToken = default)
    {
        var filter = Builders<BookDetails>.Filter.Empty;

        return _collection
            .Find(filter)
            .ToListAsync(cancellationToken);
    }

    public Task<BookDetails> GetAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        var filter = Builders<BookDetails>.Filter
            .Eq(e => e.Id, id);

        return _collection
            .Find(filter)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Guid> UpsertAsync(BookDetails request, CancellationToken cancellationToken = default)
    {
        var filter = Builders<BookDetails>.Filter.Eq(e => e.Id, request.Id);

        var updates = Builders<BookDetails>.Update
            .SetOnInsert(s => s.Id, request.Id)
            .Set(s => s.Description, request.Description)
            .Set(s => s.Title, request.Title);

       var response = await _collection.UpdateOneAsync(
            filter,
            updates,
            new UpdateOptions { IsUpsert = true },
            cancellationToken: cancellationToken);

       return response.UpsertedId.AsGuid;
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}