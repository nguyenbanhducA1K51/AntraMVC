using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    //all the business logic methods relating to movies

   List<MovieCardModel> GetTop20GrossingMovies();
   MovieDetailsModel GetMovieDetails(int id);
   bool DeleteMovie(int id);
}