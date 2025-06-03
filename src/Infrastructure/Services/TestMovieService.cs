using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class TestMovieService: IMovieService
{
    public List<MovieCardModel> GetTop20GrossingMovies()
    {
        var movies = new List<MovieCardModel>()
        {
            new MovieCardModel()
            {
                Id = 1, Title = "Inception",
                PosterURL = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"
            },
            new MovieCardModel()
            {
                Id = 2, Title = "Interstellar",
                PosterURL = "https://image.tmdb.org/t/p/w342//gEU2QniE6E77NI6lCU6MxlNBvIx.jpg"
            },
            new MovieCardModel()
            {
                Id = 3, Title = "The Dark Knight",
                PosterURL = "https://image.tmdb.org/t/p/w342//qJ2tW6WMUDux911r6m7haRef0WH.jpg "
            }
        };
        return movies;
    }

    public MovieDetailsModel GetMovieDetails(int id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }
}