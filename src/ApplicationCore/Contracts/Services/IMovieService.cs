using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
 

 Task<  List<MovieCardModel>> GetTop20GrossingMovies();
   Task<MovieDetailsModel> GetMovieDetails(int id);
   Task<MovieCardModel> GetMovieById(int? id);
   Task<bool> DeleteMovie(int id);
   Task<MovieDetailsModel> GetMovieDetailsAsync(int id);
   Task<PaginatedResultSetModel<MovieCardModel>> GetMovieByGenre(int genreId, int pageNumber, int pageSize);
}