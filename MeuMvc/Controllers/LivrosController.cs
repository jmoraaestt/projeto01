using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuMvc.Data;
using MeuMvc.Models;

namespace MeuMvc.Controllers;

public class LivrosController : Controller
{
    private readonly AppDbContext _context;

    public LivrosController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(string? busca)
    {
        var query = _context.Livros.AsQueryable(); 

        if (!string.IsNullOrWhiteSpace(busca))
        {
            query = query.Where(l => l.Titulo.Contains(busca) || l.Autor.Contains(busca));
        }

        ViewData["Busca"] = busca;

        var livros = await query.OrderBy(l => l.Titulo).ToListAsync();
        return View(livros);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Livro livro)
    {
        if (!ModelState.IsValid) return View(livro);

        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return NotFound();

        return View(livro);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return NotFound();

        return View(livro);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Livro livro)
    {
        //if (id != null) return NotFound();
        if (id != livro.Id) return NotFound();

        if (!ModelState.IsValid) return View(livro);

        _context.Livros.Update(livro);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

        public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return NotFound();

        return View(livro);
    }

    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
    {

        var livro = await _context.Livros.FindAsync(id);
        if(livro == null) return NotFound();

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
