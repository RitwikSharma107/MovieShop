using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepository: BaseRepository<Genres>, IGenreRepository
{
    public GenreRepository(MovieShopDbContext movieshopDbContext) : base(movieshopDbContext)
    {
    }
}