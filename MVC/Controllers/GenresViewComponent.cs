using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Models;

namespace ClientMVCMovieShop.Controllers
{
    /* Genres View Component (Partial view + Server-side code) */
    // ViewComponents are useful when the rendering logic involves not just HTML markup but also server-side code that retrieves data or performs other operations
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;

        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // Injection method to put the ViewComponent in a View
        public async Task<IViewComponentResult> InvokeAsync(string? selectedGenre)
        {
            var genres = await _genreService.GetAllGenresAsync();
            var viewModel = new GenreSelectModel
            {
                Genres = genres.ToList(),
                SelectedGenre = selectedGenre
            };
            // View for the ViewComponent (Inside Views/Shared/Components/Genres)
            return View("_GenreDropDown", viewModel);
        }
    }
}