using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers;

public class CastController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        return View();
    }
}