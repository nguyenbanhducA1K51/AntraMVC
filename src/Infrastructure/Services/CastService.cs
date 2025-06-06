using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class CastService : ICastService
{
    private readonly ICastRepository _castRepository;

    public CastService(ICastRepository castRepository)
    {
        _castRepository = castRepository;
    }

    public CastModel GetCastDetails(int id)
    {
        var cast = _castRepository.GetById(id);
        return new CastModel()
        {
            Id = cast.Id,
            Name = cast.Name,
            ProfilePath = cast.ProfilePath,
            Gender = cast.Gender,
            TmdbUrl = cast.TmdbUrl,
            MovieCards = cast.MovieCasts?
                .Select(mc => new MovieCardModel
                {
                    Id = mc.Movie.Id,
                    Title = mc.Movie.Title,
                    PosterURL = mc.Movie.PosterUrl
                })
                .ToList()
        };
    }
}