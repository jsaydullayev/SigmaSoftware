namespace SigmaSoftware.Data.Repositories.Contracts;
public interface IBaseRepository<T> where T : class
{
    Task<IQueryable<T>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task SaveChanges();
}
