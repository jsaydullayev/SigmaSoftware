using SigmaSoftware.Data.Data;
using SigmaSoftware.Data.Repositories.Contracts;

namespace SigmaSoftware.Data.Repositories;
public class BaseRepository<T>(CandidateContext context) : IBaseRepository<T> where T : class
{
    private readonly CandidateContext _context = context;

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task<IQueryable<T>> GetAll()
    {
        var entities = _context.Set<T>();
        return entities;
    }

    public async Task SaveChanges() => await _context.SaveChangesAsync();

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
