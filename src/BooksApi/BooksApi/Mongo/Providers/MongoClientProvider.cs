using System.Security.Authentication;
using BooksApi.Mongo.Interfaces;
using BooksApi.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BooksApi.Mongo.Providers;

public class MongoClientProvider : IMongoClientProvider
{
    public MongoClientProvider(IOptions<MongoOptions> options)
    {
        var mongoOptions = options.Value;

        var settings = MongoClientSettings.FromUrl(
            new MongoUrl(mongoOptions.ConnectionString)
        );
        settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
        settings.ServerSelectionTimeout = mongoOptions.ServerSelectionTimeout;

        Client = new MongoClient(settings);
    }
    
    public IMongoClient Client { get; }
}