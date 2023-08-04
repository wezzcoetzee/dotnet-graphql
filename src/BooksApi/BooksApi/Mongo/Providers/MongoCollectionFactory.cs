using BooksApi.Mongo.Interfaces;
using BooksApi.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BooksApi.Mongo.Providers;

public class MongoCollectionFactory : IMongoCollectionFactory
{
    private readonly IMongoClient _client;
    private readonly MongoOptions _options;

    public MongoCollectionFactory(
        IOptions<MongoOptions> options,
        IMongoClientProvider clientProvider)
    {
        _options = options.Value;
        _client = clientProvider.Client;
    }

    /// <inheritdoc />
    public IMongoCollection<TEntity> Get<TEntity>(
        string collectionName, Func<MongoOptions, string> databaseSelector)
    {
        return _client.GetDatabase(databaseSelector(_options))
            .GetCollection<TEntity>(collectionName);
    }
}