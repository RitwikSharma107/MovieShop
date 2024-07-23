using ApplicationCore.Model.Response;

namespace ApplicationCore.Contracts.Services;

public interface IGenreService
{
    /*************************************************************************************/
    /* Synchronous Method */
    /*************************************************************************************/
    public IEnumerable<GenreResponseModel> GetAllGenres();
    
    /*************************************************************************************/
    /* Asynchronous Method */
    /*************************************************************************************/
    public Task<IEnumerable<GenreResponseModel>> GetAllGenresAsync();
}