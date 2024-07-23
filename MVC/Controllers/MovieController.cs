using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers;

public class MovieController : Controller
{
    
    // Movie Card
    private readonly IMovieService _movieService;
    
    public MovieController(IMovieService movieService)
    {
        this._movieService = movieService;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult HighestGrossing()
    {
        return View();
    }
    
    // Synchronous //
    // [HttpPost]
    // public IActionResult HighestGrossing(int count)
    // {
    //     ViewBag.Count = count;
    //     var highestGrossingMovies = _movieService.GetHighestGrossingMovies(count);
    //     return View("HighestGrossingResult", highestGrossingMovies);
    // }
    
    // Asynchronous //
    [HttpPost]
    public async Task<IActionResult> HighestGrossingAsync(int count)
    {
        ViewBag.Count = count;
        var highestGrossingMovies = await _movieService.GetHighestGrossingMoviesAsync(count);
        return View("HighestGrossingResult", highestGrossingMovies);
    }
    
    /* Enter ID to get Movie Details */
    // [HttpGet]
    // public IActionResult GetMovieDetails()
    // {
    //     return View();
    // }
    //
    // [HttpPost]
    // public IActionResult GetMovieDetails(int id)
    // {
    //     ViewBag.Id = id;
    //     var selectedMovie = _movieService.GetMovieDetails(id);
    //     return View("GetMovieDetailsResult", selectedMovie);
    // }
    
    /* Select on Home Page to get Movie Details */
    // Synchronous // 
    // [HttpGet]
    // public IActionResult GetMovieDetailsResult(int id)
    // {
    //     var selectedMovie = _movieService.GetMovieDetails(id);
    //     return View(selectedMovie);
    // }
    
    // Asynchronous //
    [HttpGet]
    public async Task<IActionResult> GetMovieDetailsResultAsync(int id)
    {
        var selectedMovie = await _movieService.GetMovieDetailsAsync(id);
        return View(selectedMovie);
    }
    
    
}