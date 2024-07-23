namespace ApplicationCore.Contracts.Repository;

public interface IRepository<T> where T : class
{
    /*************************************************************************************/
    /* Synchronous Methods */
    /*************************************************************************************/
    public int Insert(T entity);
    public int Update(T entity);
    public int Delete(int id);
    public T GetById(int id);
    public IEnumerable<T> GetAll();
    
    /*************************************************************************************/
    /* Asynchronous Methods */
    /*************************************************************************************/
    public Task<int> InsertAsync(T entity);
    public Task<int> UpdateAsync(T entity);
    public Task<int> DeleteAsync(int id);
    public Task<T?> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
}