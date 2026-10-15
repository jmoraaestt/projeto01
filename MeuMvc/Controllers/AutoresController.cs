using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuMvc.Data;
using MeuMvc.Models;
using System.Reflection.Metadata.Ecma335;

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

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var autor = await _context.Autores.FindAsync(id);
        if(autor == null) return NotFound();

        return View(autor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Autor autor)
    {
        if (id != autor.Id) return NotFound();

        if(!ModelState.IsValid)
        {
            return View(autor);
        }

        _context.Autores.Update(autor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null) return NotFound();

        var autor = await _context.Autores.FindAsync(id);
        if(autor == null)
        {
            return NotFound();
        }

        return View(autor);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(int id)
    {

        var autor = await _context.Autores.FindAsync(id);
        if (autor == null) return NotFound();

        _context.Autores.Remove(autor);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }



}
