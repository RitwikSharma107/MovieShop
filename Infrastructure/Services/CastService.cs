using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Model.Response;

namespace Infrastructure.Services;

public class CastService : ICastService
{
    private readonly ICastRepository _castRepository;

    public CastService(ICastRepository castRepository)
    {
        this._castRepository = castRepository;
    }
    
    /*************************************************************************************/
    /* Synchronous Method */
    /*************************************************************************************/
    public CastResponseModel GetCastDetails(int id)
    {
        var cast = _castRepository.GetById(id);
        
        if (cast == null)
        {
            throw new KeyNotFoundException($"Cast with ID {id} not found.");
        }
        
        var response = new CastResponseModel
        {
            Id = cast.Id,
            Gender = cast.Gender,
            Name = cast.Name,
            ProfilePath = cast.ProfilePath,
            TmdbUrl = cast.TmdbUrl
        };
        return response;
        
    }

    /*************************************************************************************/
    /* Asynchronous Method */
    /*************************************************************************************/
    public async Task<CastResponseModel> GetCastDetailsAsync(int id)
    {
        var cast = await _castRepository.GetByIdAsync(id);
        
        if (cast == null)
        {
            throw new KeyNotFoundException($"Cast with ID {id} not found.");
        }
        
        var response = new CastResponseModel
        {
            Id = cast.Id,
            Gender = cast.Gender,
            Name = cast.Name,
            ProfilePath = cast.ProfilePath,
            TmdbUrl = cast.TmdbUrl
        };
        return response;
    }
}