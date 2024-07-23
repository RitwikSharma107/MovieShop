using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}