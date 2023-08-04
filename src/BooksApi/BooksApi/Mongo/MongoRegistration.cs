using BooksApi.Models;
using BooksApi.Mongo.Interfaces;
using BooksApi.Mongo.Providers;
using BooksApi.Options;
using BooksApi.Repositories;
using Microsoft.Extensions.Options;

namespace BooksApi.Mongo;

public static class MongoRegistration
{
    internal static IServiceCollection AddMongo(
        this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<IValidateOptions<MongoOptions>, MongoOptionsValidator>()
            .AddOptions<MongoOptions>()
            .Bind(configuration.GetSection(nameof(MongoOptions)))
            .ValidateOnStart();

        return services
            .AddSingleton<IMongoClientProvider, MongoClientProvider>()
            .AddTransient<IMongoDatabaseProvider, MongoDatabaseProvider>()
            .AddTransient<IMongoCollectionFactory, MongoCollectionFactory>()
            .AddMongoCollections();
    }

    private static IServiceCollection AddMongoCollections(this IServiceCollection services)
    {
        return services
            .AddMongoCollection<BookDetails>(BookRepository.CollectionName, o => o.DatabaseName);
    }

    private static IServiceCollection AddMongoCollection<T>(
        this IServiceCollection services, string collectionName, Func<MongoOptions, string> dbSelector) 
        where T : class
    {
        services.AddTransient<T>(sp => (T)sp.GetRequiredService<IMongoCollectionFactory>()
            .Get<T>(collectionName, dbSelector));

        return services;
    }
}