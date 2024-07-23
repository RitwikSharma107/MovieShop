using ApplicationCore.Entity;
using ApplicationCore.Model.Response;

namespace ApplicationCore.Contracts.Repository;

public interface IMovieRepository:IRepository<Movies>
{
    /*************************************************************************************/
    /* Synchronous Method */
    /*************************************************************************************/
    public IEnumerable<Movies> GetByGenre(string genre);
    
    /*************************************************************************************/
    /* Asynchronous Method */
    /*************************************************************************************/
    public Task<IEnumerable<Movies>> GetByGenreAsync(string genre);
}