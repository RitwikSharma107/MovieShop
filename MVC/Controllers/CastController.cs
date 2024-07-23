using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers;

public class CastController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}