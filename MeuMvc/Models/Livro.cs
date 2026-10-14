namespace MeuMvc.Models;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = "";
    public int Ano { get; set; }

    public int AutorId{get;set;} // chave estrangeira
    public Autor? Autor {get;set;} // Navegação, não vira coluna
}