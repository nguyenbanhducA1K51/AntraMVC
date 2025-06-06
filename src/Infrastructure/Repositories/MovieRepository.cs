using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository: BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
    {
    }

    public IEnumerable<Movie> GetTop20GrossingMovies()
    {
        var movies = _movieShopDbContext.Movie.OrderByDescending(m => m.Revenue).Take(20);
        return movies;
    }

    public IEnumerable<Movie> GetHighestGrossingMovies()
    {
        var maxRevenue = _movieShopDbContext.Movie.Max(m => m.Revenue);
        
        return _movieShopDbContext.Movie
            .Where(m => m.Revenue == maxRevenue)
            .ToList();
        
    }

    public Movie GetMovieById(int id)
    {
      throw new NotImplementedException();
    }
    
    public async Task<Movie> GetByIdAsync(int id)
    {
        return await  _movieShopDbContext.Movie
            .Include(m => m.Trailers)
            .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
            .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

 
}