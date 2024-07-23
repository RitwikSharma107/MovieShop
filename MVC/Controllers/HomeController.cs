using System.Diagnostics;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieShop.Models;

namespace MovieShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    // Movie Card
    private readonly IMovieService _movieService;
    
    // Genres List
    private readonly IGenreService _genreService;
    
    public HomeController(ILogger<HomeController> logger, IMovieService movieService,  IGenreService _genreService)
    {
        _logger = logger;
        this._movieService = movieService;
        this._genreService = _genreService;
    }
    
    /*************************************************************************************/
    /* Synchronous Method */
    /*************************************************************************************/
    // public IActionResult Index(string genre)
    // {
    //     var result = string.IsNullOrEmpty(genre) ? 
    //         _movieService.GetAllMovies() : 
    //         _movieService.GetMoviesByGenre(genre);
    //
    //     List<MovieCard> movieCards = result.Select(item => new MovieCard
    //     {
    //         Id = item.Id,
    //         PosterUrl = item.PosterUrl
    //     }).ToList();
    //
    //     // Ensure ViewBag.SelectedGenre is set to maintain the selected genre
    //     ViewBag.SelectedGenre = genre;
    //
    //     // Returns the Index view, passing the movieCards list to it.
    //     return View("Index", movieCards);
    // }
    
    /*************************************************************************************/
    /* Asynchronous Method */
    /*************************************************************************************/
    
    public async Task<IActionResult> Index(string genre, int pageSize = 30, int pageNumber = 1)
    {
        PaginatedResultSet<MovieResponseModel> result = await _movieService.GetMoviesbyPaginationAsync(genre, pageSize, pageNumber);

        var movieCardModels = result.Items.Select(movie => new MovieCard
        {
            Id = movie.Id,
            PosterUrl = movie.PosterUrl
        }).ToList();

        var paginatedResult = new PaginatedResultSet<MovieCard>
        {
            Items = movieCardModels,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize,
            TotalItems = result.TotalItems
        };
        
        // Ensure ViewBag.SelectedGenre is set to maintain the selected genre
        ViewBag.SelectedGenre = genre;
        
        // Returns the Index view, passing the movieCards list to it.
        return View("Index", paginatedResult);
    }

    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}