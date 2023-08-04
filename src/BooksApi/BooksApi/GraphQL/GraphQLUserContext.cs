using System.Security.Claims;

namespace BooksApi.GraphQL;

public class GraphQLUserContext : Dictionary<string, object>
{
    public ClaimsPrincipal User { get; set; }
}