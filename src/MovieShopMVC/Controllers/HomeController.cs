using System.Diagnostics;
using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers;

//HomeController homeController = new HomeController(?);
public class HomeController : Controller
{
    private readonly IMovieService movieService;
    
    public HomeController(IMovieService _movieService)
    {
        movieService = _movieService;
    }

    public IActionResult Index()
    { 
        // var movieService = new MovieService();
        var movies= movieService.GetTop20GrossingMovies();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        //ViewData["Key"] = value;
        //IDictinary<string, object >
        // ViewData["Message"] = "Hello from ViewData";
        // ViewData["Age"] = 30;
        ViewBag.Message = "Hello from ViewData";
        ViewBag.Age = 30;
        return View();
    }

    public IActionResult TopMovies()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}