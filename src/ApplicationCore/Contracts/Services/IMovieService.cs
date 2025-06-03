using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
 

   List<MovieCardModel> GetTop20GrossingMovies();
   MovieDetailsModel GetMovieDetails(int id);
   MovieCardModel GetMovieById(int? id);
   bool DeleteMovie(int id);
}