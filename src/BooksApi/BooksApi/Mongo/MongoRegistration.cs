using BooksApi.Models;
using BooksApi.Options;
using BooksApi.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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
        
        var config = configuration.GetSection(nameof(MongoOptions)).Get<MongoOptions>();

        return services
            .AddSingleton(new MongoClient(config!.ConnectionString))
            .AddScoped<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<MongoClient>();
                return client.GetDatabase(config.DatabaseName);
            })
            .AddScoped<IMongoCollection<BookDetails>>(sp =>
            {
                var database = sp.GetRequiredService<IMongoDatabase>();
                return database.GetCollection<BookDetails>(BookRepository.CollectionName);
            })
            .AddScoped<IBookRepository, BookRepository>();
    }
}