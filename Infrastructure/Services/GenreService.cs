using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Model.Response;

namespace Infrastructure.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        this._genreRepository = genreRepository;
    }
    
    /*************************************************************************************/
    /* Synchronous Method */
    /*************************************************************************************/
    public IEnumerable<GenreResponseModel> GetAllGenres()
    {
        var result = _genreRepository.GetAll();
        List<GenreResponseModel> genreResponseModels = new List<GenreResponseModel>();
        foreach (var item in result)
        {
            GenreResponseModel model = new GenreResponseModel();
            model.Id = item.Id;
            model.Name = item.Name;
            genreResponseModels.Add(model);
        }
        return genreResponseModels;
    }

    /*************************************************************************************/
    /* Asynchronous Method */
    /*************************************************************************************/
    public async Task<IEnumerable<GenreResponseModel>> GetAllGenresAsync()
    {
        var result = await _genreRepository.GetAllAsync();
        List<GenreResponseModel> genreResponseModels = new List<GenreResponseModel>();
        foreach (var item in result)
        {
            GenreResponseModel model = new GenreResponseModel();
            model.Id = item.Id;
            model.Name = item.Name;
            genreResponseModels.Add(model);
        }
        return genreResponseModels;
    }
}