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

    public async Task< IEnumerable<Movie>> GetTop20GrossingMovies()
    {
        var movies = await _movieShopDbContext.Movie.OrderByDescending(m => m.Revenue).Take(20).ToListAsync(); ;
        return movies;
    }

    public async Task< IEnumerable<Movie>> GetHighestGrossingMovies()
    {
        var maxRevenue = await _movieShopDbContext.Movie.MaxAsync(m => m.Revenue);

        return await _movieShopDbContext.Movie
            .Where(m => m.Revenue == maxRevenue)
            .ToListAsync();
    }

    public async Task<Movie> GetMovieById(int id)
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
    
    public async Task<(List<Movie>,int TotalPage)> GetMoviesByGenre(int genreId, int pageNumber, int pageSize)
    {
        var query = _movieShopDbContext.Movie
            .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));

        var totalCount = await query.CountAsync();

        var movies = await query
            .OrderBy(m => m.Title)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (movies, totalCount);
        
    }

 
}