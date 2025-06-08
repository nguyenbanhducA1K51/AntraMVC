using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T: class
{
    protected readonly MovieShopDbContext _movieShopDbContext;
    public BaseRepository(MovieShopDbContext movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }
    
    public async  Task<T> Insert(T entity)
    { 
        await _movieShopDbContext.Set<T>().AddAsync(entity);      // ✅ async add
        await _movieShopDbContext.SaveChangesAsync();             // ✅ async save
        return entity;
    }

    public async Task<T?> DeleteById(int id) 
    {
        // 1. Look up the entity asynchronously
        var entity = await _movieShopDbContext.Set<T>().FindAsync(id);

        if (entity is null)                       // not found → nothing to delete
            return null;

        // 2. Mark for removal
        _movieShopDbContext.Set<T>().Remove(entity);

        // 3. Persist the change asynchronously
        await _movieShopDbContext.SaveChangesAsync();

        // 4. Return the deleted entity (or just `true`/`false` if you prefer)
        return entity;
    }
    public async Task<T> Update(T entity)
    {
        _movieShopDbContext.Entry(entity).State = EntityState.Modified;
        await _movieShopDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task< IEnumerable<T>> GetAll()
    {
        return await _movieShopDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _movieShopDbContext.Set<T>().FindAsync(id);
    }
}