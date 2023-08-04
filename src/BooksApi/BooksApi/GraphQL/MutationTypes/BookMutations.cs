using BooksApi.Models;
using BooksApi.Repositories;

namespace BooksApi.GraphQL.MutationTypes;

public class BookMutations
{
    public async Task<Guid> AddAsync([Service] IBookRepository repository,
        BookDetails book)
    {
        return await repository.UpsertAsync(book);
    }

    public async Task<Guid> UpdateAsync([Service] IBookRepository repository,
        BookDetails book)
    {
        return await repository.UpsertAsync(book);
    }

    public async Task<bool> DeleteAsync([Service] IBookRepository repository,
        Guid id)
    {
        return await repository.DeleteAsync(id);
    }
}