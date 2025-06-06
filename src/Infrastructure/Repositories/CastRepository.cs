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

  
    public Cast? GetById(int id)
    {
        return _movieShopDbContext.Cast
            .Include(c => c.MovieCasts)
            .ThenInclude(mc => mc.Movie)
            .FirstOrDefault(c => c.Id == id);
    }
}