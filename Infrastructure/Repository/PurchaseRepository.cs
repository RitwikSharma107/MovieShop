using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class PurchaseRepository : BaseRepository<Purchases>, IPurchaseRepository
{
    public PurchaseRepository(MovieShopDbContext movieshopDbContext) : base(movieshopDbContext)
    {
    }
}