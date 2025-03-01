using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Form()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Submit(string name, string email, string message)
    {
        ViewBag.Name = name;
        ViewBag.Email = email;
        ViewBag.Message = message;
        return View();
    }
    [HttpGet]
    public IActionResult Image(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return Content("Invalid image name");
        }
        
        return File($"wwwroot/images/{name}", "image/jpeg");
    }    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
