using MongoDB.Driver;

namespace BooksApi.Mongo.Interfaces;

public interface IMongoClientProvider
{
    IMongoClient Client { get; }
}