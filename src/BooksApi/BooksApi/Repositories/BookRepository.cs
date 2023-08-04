using BooksApi.Models;

namespace BooksApi.Repositories;

public interface IBookRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<BookDetails>> GetAsync();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BookDetails> GetAsync(Guid id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<Guid> UpsertAsync(BookDetails request);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);
}

public class BookRepository : IBookRepository
{
    public BookRepository()
    {
        
    }
    
    public Task<IEnumerable<BookDetails>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BookDetails> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> UpsertAsync(BookDetails request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}