using BooksApi.Options;
using MongoDB.Driver;

namespace BooksApi.Mongo.Interfaces;

public interface IMongoCollectionFactory
{
    IMongoCollection<TEntity> Get<TEntity>(string collectionName, Func<MongoOptions, string> databaseSelector);
}