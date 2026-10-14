using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MeuMvc.Models;

namespace MeuMvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AboutMe() 
    {
        return View();
    }

    public IActionResult Livro() 
    {
        var livro = new Livro
        {
                Titulo = "Dom Casmurro",
                Ano = 1899,
        };
        return View(livro);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
