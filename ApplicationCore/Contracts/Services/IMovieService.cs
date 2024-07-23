using ApplicationCore.Model.Response;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    /*************************************************************************************/
    /* Synchronous Methods */
    /*************************************************************************************/
    public IEnumerable<MovieResponseModel> GetAllMovies();
    public IEnumerable<MovieResponseModel> GetHighestGrossingMovies(int count);
    public MovieResponseModel GetMovieDetails(int id);
    public IEnumerable<MovieResponseModel> GetMoviesByGenre(string genre);
    
    /*************************************************************************************/
    /* Asynchronous Methods */
    /*************************************************************************************/
    public Task<IEnumerable<MovieResponseModel>> GetAllMoviesAsync();
    public Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMoviesAsync(int count);
    public Task<MovieResponseModel> GetMovieDetailsAsync(int id);
    public Task<IEnumerable<MovieResponseModel>> GetMoviesByGenreAsync(string genre);
    
    // Pagination Method
    public Task<PaginatedResultSet<MovieResponseModel>> GetMoviesbyPaginationAsync(string genre, int pageSize, int pageNumber);
}