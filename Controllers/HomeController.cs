using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFItness.Data;
using MyFItness.Models;

namespace MyFItness.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Information()
    {
        return View();
    }

    public async Task<IActionResult> Entraineurs()
    {
        var entraineurs = await _userManager.Users.Where(u => u.IsTrainer).ToListAsync();
        return View(entraineurs);
    }


    public async Task<IActionResult> Messagerie()
    {

        var entraineurs = await _userManager.Users.Where(u => u.IsTrainer).ToListAsync();
        return View(entraineurs);
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
