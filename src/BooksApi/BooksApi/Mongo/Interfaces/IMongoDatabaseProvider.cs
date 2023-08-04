using BooksApi.Options;
using MongoDB.Driver;

namespace BooksApi.Mongo.Interfaces;

public interface IMongoDatabaseProvider
{
    IMongoDatabase Get(Func<MongoOptions, string> databaseSelector);
}