using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class UserRepository : BaseRepository<Users>, IUserRepository
{
    public UserRepository(MovieShopDbContext movieshopDbContext) : base(movieshopDbContext)
    {
    }
}