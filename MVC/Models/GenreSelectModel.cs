using ApplicationCore.Model.Response;

namespace MovieShop.Models;

public class GenreSelectModel
{
    public List<GenreResponseModel> Genres { get; set; }
    public string SelectedGenre { get; set; }
}