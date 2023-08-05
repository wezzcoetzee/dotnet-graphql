using System.Security.Claims;

namespace BooksApi.GraphQL;

public class GraphQlUserContext : Dictionary<string, object>
{
    public ClaimsPrincipal User { get; set; }
}