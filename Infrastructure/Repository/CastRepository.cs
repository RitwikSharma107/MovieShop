using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CastRepository : BaseRepository<Casts>, ICastRepository
{
    public CastRepository(MovieShopDbContext movieshopDbContext) : base(movieshopDbContext)
    {
    }
}