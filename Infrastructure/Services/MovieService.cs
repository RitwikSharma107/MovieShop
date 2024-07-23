using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entity;
using ApplicationCore.Model.Response;

namespace Infrastructure.Services;

public class MovieService : IMovieService
{
    
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        this._movieRepository = movieRepository;
    }
    
    /*************************************************************************************/
    /* Synchronous Methods */
    /*************************************************************************************/
    public IEnumerable<MovieResponseModel> GetAllMovies()
    {
        var result = _movieRepository.GetAll();
        List<MovieResponseModel> movieResponseModels = new List<MovieResponseModel>();
        foreach (var item in result)
        {
            MovieResponseModel model = new MovieResponseModel();
            model.Id = item.Id;
            model.Title = item.Title;
            model.PosterUrl=item.PosterUrl; 
            movieResponseModels.Add(model);
        }
        return movieResponseModels;
    }

    public IEnumerable<MovieResponseModel> GetHighestGrossingMovies(int count)
    {
        var result = 
            _movieRepository.GetAll()
            .OrderByDescending(m => m.Revenue)
            .Take(count)
            .Select(m => new MovieResponseModel
            {
                Id = m.Id,
                Title = m.Title,
                Revenue = m.Revenue
            })
            .ToList();
        return result;
    }

    public MovieResponseModel GetMovieDetails(int id)
    {
        var movie = _movieRepository.GetById(id); // Overriden Method

        if (movie == null)
        {
            throw new KeyNotFoundException($"Movie with ID {id} not found.");
        }

        var response = new MovieResponseModel
        {
            Id = movie.Id,
            BackdropUrl = movie.BackdropUrl,
            Budget = movie.Budget,
            CreatedBy = movie.CreatedBy,
            CreatedDate = movie.CreatedDate,
            ImdbUrl = movie.ImdbUrl,
            OriginalLanguage = movie.OriginalLanguage,
            Overview = movie.Overview,
            PosterUrl = movie.PosterUrl,
            Price = movie.Price,
            ReleaseDate = movie.ReleaseDate,
            Revenue = movie.Revenue,
            RunTime = movie.RunTime,
            Tagline = movie.Tagline,
            Title = movie.Title,
            TmdbUrl = movie.TmdbUrl,
            UpdatedBy = movie.UpdatedBy,
            UpdatedDate = movie.UpdatedDate,
            Casts = movie.MovieCasts.Select(mc => new CastResponseModel
            {
                Id = mc.Cast.Id,
                Name = mc.Cast.Name,
                Gender = mc.Cast.Gender,
                TmdbUrl = mc.Cast.TmdbUrl,
                ProfilePath = mc.Cast.ProfilePath,
                Character = mc.Character // Conjunction Table Property
            }).ToList(),
            Genres = movie.MovieGenres.Select(mg => new GenreResponseModel
            {
                Id = mg.Genre.Id,
                Name = mg.Genre.Name,
            }).ToList()
        };
        return response;
    }

    public IEnumerable<MovieResponseModel> GetMoviesByGenre(string genre)
    {
        var result = _movieRepository.GetByGenre(genre);
        List<MovieResponseModel> moviesResponseModels = new List<MovieResponseModel>();
        foreach (var item in result)
        {
            MovieResponseModel model = new MovieResponseModel
            {
                Id = item.Id,
                Title = item.Title,
                PosterUrl=item.PosterUrl
            };
            moviesResponseModels.Add(model);
        }

        return moviesResponseModels;
    }

    /*************************************************************************************/
    /* Asynchronous Methods */
    /*************************************************************************************/
    public async Task<IEnumerable<MovieResponseModel>> GetAllMoviesAsync()
    {
        var result = await _movieRepository.GetAllAsync();
        return result.Select(item => new MovieResponseModel
        {
            Id = item.Id,
            Title = item.Title,
            PosterUrl = item.PosterUrl
        }).ToList();
    }

    public async Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMoviesAsync(int count)
    {
        var result = await _movieRepository.GetAllAsync();
        return result.OrderByDescending(m => m.Revenue)
            .Take(count)
            .Select(m => new MovieResponseModel
            {
                Id = m.Id,
                Title = m.Title,
                Revenue = m.Revenue
            }).ToList();
    }

    public async Task<MovieResponseModel> GetMovieDetailsAsync(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id); 

        if (movie == null)
        {
            throw new KeyNotFoundException($"Movie with ID {id} not found.");
        }

        return new MovieResponseModel
        {
            Id = movie.Id,
            BackdropUrl = movie.BackdropUrl,
            Budget = movie.Budget,
            CreatedBy = movie.CreatedBy,
            CreatedDate = movie.CreatedDate,
            ImdbUrl = movie.ImdbUrl,
            OriginalLanguage = movie.OriginalLanguage,
            Overview = movie.Overview,
            PosterUrl = movie.PosterUrl,
            Price = movie.Price,
            ReleaseDate = movie.ReleaseDate,
            Revenue = movie.Revenue,
            RunTime = movie.RunTime,
            Tagline = movie.Tagline,
            Title = movie.Title,
            TmdbUrl = movie.TmdbUrl,
            UpdatedBy = movie.UpdatedBy,
            UpdatedDate = movie.UpdatedDate,
            Casts = movie.MovieCasts.Select(mc => new CastResponseModel
            {
                Id = mc.Cast.Id,
                Name = mc.Cast.Name,
                Gender = mc.Cast.Gender,
                TmdbUrl = mc.Cast.TmdbUrl,
                ProfilePath = mc.Cast.ProfilePath,
                Character = mc.Character // Conjunction Table Property
            }).ToList(),
            Genres = movie.MovieGenres.Select(mg => new GenreResponseModel
            {
                Id = mg.Genre.Id,
                Name = mg.Genre.Name,
            }).ToList()
        };
    }

    public async Task<IEnumerable<MovieResponseModel>> GetMoviesByGenreAsync(string genre)
    {
        var result = await _movieRepository.GetByGenreAsync(genre); 
        return result.Select(item => new MovieResponseModel
        {
            Id = item.Id,
            Title = item.Title,
            PosterUrl = item.PosterUrl
        }).ToList();
    }
    
    // Pagination Method
    public async Task<PaginatedResultSet<MovieResponseModel>> GetMoviesbyPaginationAsync(string genre, int pageSize, int pageNumber)
    {
        var result = string.IsNullOrEmpty(genre) ? 
            await GetAllMoviesAsync() : 
            await GetMoviesByGenreAsync(genre);
   
        var totalItems = result.Count();
        var moviesToReturn = result
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PaginatedResultSet<MovieResponseModel>
        {
            Items = moviesToReturn,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalItems = totalItems
        };
    }
}