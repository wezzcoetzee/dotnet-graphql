using BooksApi.Models;
using BooksApi.Repositories;

namespace BooksApi.GraphQL.QueryTypes;

public class BookQueries
{
    public async Task<IEnumerable<BookDetails>> GetAsync([Service] BookRepository repository)
    {
        return await repository.GetAsync();
    }

    public async Task<BookDetails> GetAsync([Service] BookRepository repository, Guid id)
    {
        return await repository.GetAsync(id);
    }
}