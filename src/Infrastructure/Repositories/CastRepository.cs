using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Repositories;

public class CastRepository : BaseRepository<Cast>, ICastRepository
{
    public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
    }

  
    public async Task<Cast?> GetById(int id)
    {
        return await _movieShopDbContext.Cast
            .Include(c => c.MovieCasts)
            .ThenInclude(mc => mc.Movie)
            .FirstOrDefaultAsync(c => c.Id == id); // ✅ async version
    }
}