using BooksApi.Mongo.Interfaces;
using BooksApi.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BooksApi.Mongo.Providers;

public class MongoDatabaseProvider : IMongoDatabaseProvider
{
    private readonly IMongoClient _client;
    private readonly MongoOptions _options;

    public MongoDatabaseProvider(
        IMongoClientProvider clientProvider,
        IOptions<MongoOptions> options)
    {
        _client = clientProvider.Client;
        _options = options.Value;
    }

    /// <inheritdoc />
    public IMongoDatabase Get(Func<MongoOptions, string> databaseSelector)
    {
        var dbName = databaseSelector(_options);
        return _client.GetDatabase(dbName);
    }
}