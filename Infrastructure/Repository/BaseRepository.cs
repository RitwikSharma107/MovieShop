using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly MovieShopDbContext _movieshopDbContext;

    public BaseRepository(MovieShopDbContext movieshopDbContext)
    {
        this._movieshopDbContext = movieshopDbContext;

    }
    
    /*************************************************************************************/
    /* Synchronous Methods */
    /*************************************************************************************/
    
    public int Insert(T entity)
    {
        _movieshopDbContext.Set<T>().Add(entity);
        return _movieshopDbContext.SaveChanges();
    }

    public int Update(T entity)
    {
        _movieshopDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return _movieshopDbContext.SaveChanges();
    }

    public int Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _movieshopDbContext.Set<T>().Remove(entity);
            return 1;
        }
        return 0;
    }
    
    // Virtual because it will be overridden in Movie Repository (Join Table)
    public virtual T GetById(int id)
    {
        return _movieshopDbContext.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _movieshopDbContext.Set<T>().ToList();
    }
    
    
    
    /*************************************************************************************/
    /* Asynchronous Methods */
    /*************************************************************************************/
    
    public async Task<int> InsertAsync(T entity)
    {
        _movieshopDbContext.Set<T>().AddAsync(entity);
        return await _movieshopDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _movieshopDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _movieshopDbContext.SaveChangesAsync();
    }


    public async Task<int> DeleteAsync(int id)
    {
        var entity = GetByIdAsync(id);
        if (entity != null)
        {
            _movieshopDbContext.Set<T>().Remove(await entity);
            return 1;
        }
        return 0;
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _movieshopDbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _movieshopDbContext.Set<T>().ToListAsync();
    }
}