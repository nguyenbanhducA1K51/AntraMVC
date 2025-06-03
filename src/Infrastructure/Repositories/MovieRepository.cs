using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MovieRepository: BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
    {
        
    }
    //GetTop20GrossingMovies()
    public IEnumerable<Movie> GetTop20GrossingMovies()
    {
        var movies = _movieShopDbContext.Movie.OrderByDescending(m => m.Revenue).Take(20);
        return movies;
    }
}