using BooksApi.GraphQL.MutationTypes;
using BooksApi.GraphQL.QueryTypes;
using BooksApi.Repositories;

namespace BooksApi.Extensions;

public static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddGraphQL(configuration)
            .AddCommonServices(configuration);
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
        return services.AddTransient<IBookRepository, BookRepository>()
            .AddLogging(builder => builder.AddConsole())
            .AddHttpContextAccessor();
    }
}