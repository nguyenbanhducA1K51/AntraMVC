using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    IEnumerable<Movie> GetTop20GrossingMovies();
    IEnumerable<Movie>  GetHighestGrossingMovies();
    Movie GetMovieById(int id);
    
}