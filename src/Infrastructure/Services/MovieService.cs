using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public List<MovieCardModel> GetTop20GrossingMovies()
    {
       var movies =  _movieRepository.GetTop20GrossingMovies();
       var movieCardModels = new List<MovieCardModel>();
       foreach (var movie in movies)
       {
           movieCardModels.Add(new MovieCardModel()
           {
                Id = movie.Id, PosterURL = movie.PosterUrl, Title = movie.Title
           });
       }

       return movieCardModels;
    }

    public MovieDetailsModel GetMovieDetails(int id)
    {
        var movie = _movieRepository.GetById(id);
        if (movie != null)
        {
            var movieDetailsModel = new MovieDetailsModel()
            {
                Id = movie.Id,
                PosterURL = movie.PosterUrl,
                Title = movie.Title,
                Budget = movie.Budget,
                Overview = movie.Overview,
                TagLine = movie.TagLine,
                Revenue = movie.Revenue
            };
            return movieDetailsModel;
        }

        return null;
    }

    public bool DeleteMovie(int id)
    {
        var movie = _movieRepository.DeleteById(id);
        if (movie == null)
        {
            return false;
        }

        return true;
    }
}