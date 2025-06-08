using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Filter;

namespace MovieShopMVC.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    [ServiceFilter(typeof(LogRequestFilter))] 
    public IActionResult CreateMovie(Movie model)
    {
        return RedirectToAction("Index");
    }
}