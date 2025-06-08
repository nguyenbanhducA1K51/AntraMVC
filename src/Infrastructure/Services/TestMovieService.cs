using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class TestMovieService: IMovieService
{
    public Task<List<MovieCardModel>> GetTop20GrossingMovies()
    {
        throw new NotImplementedException();
    }

    public Task<MovieDetailsModel> GetMovieDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MovieCardModel> GetMovieById(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MovieDetailsModel> GetMovieDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResultSetModel<MovieCardModel>> GetMovieByGenre(int genreId, int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }
}