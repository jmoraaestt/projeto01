using Microsoft.EntityFrameworkCore;
using MeuMvc.Models;

namespace MeuMvc.Data;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Livro> Livros {get;set;}
    public DbSet<Autor> Autores {get;set;}
}