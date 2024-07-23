using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using ApplicationCore.Model.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MovieRepository : BaseRepository<Movies>, IMovieRepository
{
    private readonly MovieShopDbContext _movieshopDbContext;

    public MovieRepository(MovieShopDbContext movieshopDbContext) : base(movieshopDbContext)
    {
        _movieshopDbContext = movieshopDbContext;
    }

    /*************************************************************************************/
    /* Synchronous Method */
    /*************************************************************************************/
    public override Movies? GetById(int id)
    {
        return _movieshopDbContext.Movies
            .Include(m => m.MovieCasts)
                .ThenInclude(mc => mc.Cast)
            .Include(m => m.MovieGenres)
                .ThenInclude(mc => mc.Genre)
            .FirstOrDefault(m => m.Id == id);
    }

    public IEnumerable<Movies> GetByGenre(string genre)
    {
        return _movieshopDbContext.Movies
            .Where(m => m.MovieGenres
                .Any(g => g.Genre.Name == genre))
            .ToList();
    }
    
    /*************************************************************************************/
    /* Asynchronous Methods */
    /*************************************************************************************/
    public override async Task<Movies?> GetByIdAsync(int id)
    {
        return await _movieshopDbContext.Movies
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .Include(m => m.MovieGenres)
            .ThenInclude(mc => mc.Genre)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    
    public async Task<IEnumerable<Movies>> GetByGenreAsync(string genre)
    {
        return await _movieshopDbContext.Movies
            .Where(m => m.MovieGenres
                .Any(g => g.Genre.Name == genre))
            .ToListAsync();
    }
}