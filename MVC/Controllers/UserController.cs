using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}