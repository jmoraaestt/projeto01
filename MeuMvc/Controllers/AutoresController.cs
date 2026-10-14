using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuMvc.Data;
using MeuMvc.Models;

namespace MeuMvc.Controllers;


public class AutoresController : Controller
{
    private readonly AppDbContext _context;

    public AutoresController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult>Index()
    {
        var autores = await _context.Autores.Include(a => a.Livros).ToListAsync();
        return View(autores);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Autor autor)
    {
        if (!ModelState.IsValid) return View(autor);

        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }

}
