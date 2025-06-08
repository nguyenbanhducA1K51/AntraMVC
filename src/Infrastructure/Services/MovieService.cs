using System.Runtime.CompilerServices;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.Extensions.Logging;
namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly ILogger<MovieService> _logger;
    public MovieService(IMovieRepository movieRepository,ILogger<MovieService> logger)
    {
        _logger = logger;
        _movieRepository = movieRepository;
    }
    
    public async Task<List<MovieCardModel>>  GetTop20GrossingMovies()
    {
       var movies = await _movieRepository.GetTop20GrossingMovies();
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
    public async Task<MovieDetailsModel> GetMovieDetailsAsync(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        
        if (movie == null)
        {
            _logger.LogWarning($"Movie with id {id} not found");
            throw new KeyNotFoundException($"Movie with id {id} not found");
        }

        
        var dto = new MovieDetailsModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            PosterURL = movie.PosterUrl,
            Overview = movie.Overview,
            TagLine = movie.TagLine,
            Budget = movie.Budget,
            Trailers = movie.Trailers.Select(t => new TrailerModel()
            {
                Id = t.Id,
                TrailerURL = t.TrailerURL,
                Name = t.Name,
                MovieId = t.MovieId
            }).ToList(),
            Casts = movie.MovieCasts
                .Select(mc => new CastModel()
                {
                    Id = mc.Cast.Id,
                    Name = mc.Cast.Name,
                    ProfilePath = mc.Cast.ProfilePath,
                    Gender = mc.Cast.Gender,
                    TmdbUrl = mc.Cast.TmdbUrl
                })
                .ToList()
        };
        
        
        return dto;
    }
    
    public async Task<MovieDetailsModel> GetMovieDetails(int id)
    {
        // var movie = _movieRepository.GetById(id);
        var movie = await _movieRepository.GetMovieById(id);
        if (movie != null)
            
        {
            var movieDetailsModel = new MovieDetailsModel()
            {
                Id = movie.Id,
                PosterURL = movie.PosterUrl,
                Title = movie.Title,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Price = movie.Price,
                TagLine = movie.TagLine,
                Revenue = movie.Revenue,
               
                
            };
          
            return movieDetailsModel;
        }

        return null;
    }

    public async Task< MovieCardModel> GetMovieById(int? id)
    {
        if (id == null)
        {
            return null;
        }
        
        Movie movie= await _movieRepository.GetMovieById(id.Value);
        return new MovieCardModel()
        {
            Id = movie.Id,
            PosterURL = movie.PosterUrl,
            Title = movie.Title,
        };
    } 
    

    public async Task<bool> DeleteMovie(int id)
    {
        var movie = await _movieRepository.DeleteById(id);
        if (movie == null)
        {
            return false;
        }

        return true;
    }

    public async Task<PaginatedResultSetModel<MovieCardModel>> GetMovieByGenre(int genreId, int pageNumber, int pageSize)
    {
        (var movies, int TotalCount)= await _movieRepository.GetMoviesByGenre(genreId, pageNumber, pageSize);
    
        var movieCardModels = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Id = movie.Id, PosterURL = movie.PosterUrl, Title = movie.Title
            });
        }
        var paginatedResult = new PaginatedResultSetModel<MovieCardModel>()
        {
            Items = movieCardModels,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = TotalCount
        };
        return paginatedResult;
    }
}