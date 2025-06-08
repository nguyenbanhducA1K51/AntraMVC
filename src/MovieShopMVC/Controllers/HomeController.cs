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

    public async Task<IActionResult> Index()
    { 
        var movies= await movieService.GetTop20GrossingMovies();
        return View(movies);
    }

    public IActionResult Privacy()
    {
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