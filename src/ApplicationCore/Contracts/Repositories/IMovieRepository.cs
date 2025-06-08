using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    Task<IEnumerable<Movie>> GetTop20GrossingMovies();
    Task<IEnumerable<Movie>>  GetHighestGrossingMovies();
    Task<Movie> GetMovieById(int id);
    Task<Movie> GetByIdAsync(int id);
    Task<(List<Movie>,int TotalPage)> GetMoviesByGenre(int genreId, int pageNumber, int pageSize);
}