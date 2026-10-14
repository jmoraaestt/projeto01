var livros = new List<Livro>
{
    new(1, "Dom Casmurro", "Machado de Assis", 1899, 256, "Romance"),
    new(2, "Memórias Póstumas de Brás Cubas", "Machado de Assis", 1881, 208, "Romance"),
    new(3, "O Cortiço", "Aluísio Azevedo", 1890, 304, "Naturalismo"),
    new(4, "Vidas Secas", "Graciliano Ramos", 1938, 176, "Modernismo"),
    new(5, "Capitães da Areia", "Jorge Amado", 1937, 280, "Modernismo"),
    new(6, "A Hora da Estrela", "Clarice Lispector", 1977, 88, "Modernismo"),
    new(7, "Grande Sertão: Veredas", "Guimarães Rosa", 1956, 624, "Modernismo"),
    new(8, "Iracema", "José de Alencar", 1865, 160, "Romantismo"),
    new(9, "O Guarani", "José de Alencar", 1857, 400, "Romantismo"),
    new(10, "Quincas Borba", "Machado de Assis", 1891, 320, "Romance"),
};

var resultado = livros.Where(l => l.Ano > 1900);
var resultado2 = livros.Select(l => l.Titulo.ToUpper());
var resultado3 = livros.First(l => l.Ano > 1900);
var resultado4 = livros.Sum(l => l.Paginas);

Console.WriteLine(resultado3.Titulo);
Console.WriteLine(resultado4);

foreach (var l in resultado2)
    Console.WriteLine(l);

record Livro(int Id, string Titulo, string Autor, int Ano, int Paginas, string Genero);

