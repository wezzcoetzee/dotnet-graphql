using BooksApi.GraphQL.MutationTypes;
using BooksApi.GraphQL.QueryTypes;
using BooksApi.Mongo;
using BooksApi.Options;
using BooksApi.Repositories;

namespace BooksApi.Extensions;

public static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .Configure<MongoOptions>(configuration.GetSection(nameof(MongoOptions)));

        return services
            .AddCommonServices(configuration)
            .AddGraphQL(configuration)
            .AddMongo(configuration);
    }

    private static IServiceCollection AddGraphQL(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGraphQLServer()
            .AddQueryType<BookQueries>()
            .AddMutationType<BookMutations>();
        return services;
    }

    private static IServiceCollection AddCommonServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddTransient<IBookRepository, BookRepository>()
            .AddLogging(builder => builder.AddConsole())
            .AddHttpContextAccessor();
    }
}