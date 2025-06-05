using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
    private readonly ILogger<MoviesController> _logger;
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService,ILogger<MoviesController> logger)
        {
            
            _logger = logger;
            _movieService = movieService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MovieDetails(int id)
        {
            // var movie = _movieService.GetMovieDetails(id);
            //
            //
            // return View(movie);
            try
            {
                var movieDetails = await _movieService.GetMovieDetailsAsync(id);
                return Ok(movieDetails);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting movie details.");
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound();
            }

            _movieService.DeleteMovie(id);
            return RedirectToAction("Index","Home");
        }

    }
}
