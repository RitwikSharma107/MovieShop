using ApplicationCore.Model.Response;

namespace ApplicationCore.Contracts.Services;

public interface ICastService
{
    /*************************************************************************************/
    /* Synchronous Method */
    /*************************************************************************************/
    public CastResponseModel GetCastDetails(int id);
    
    /*************************************************************************************/
    /* Asynchronous Method */
    /*************************************************************************************/
    public Task<CastResponseModel> GetCastDetailsAsync(int id);
}