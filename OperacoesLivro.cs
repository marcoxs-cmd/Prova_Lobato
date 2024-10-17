using EF.Exemplo6;
using Microsoft.EntityFrameworkCore;

public static class OperacoesLivro
{
    public static void Incluir()
    {
        using var db = new AplicacaoDbContext();
        var livro = new Livro();
        Console.WriteLine("ISBN do livro: ");
        livro.ISBN = Console.ReadLine();
        Console.WriteLine("Título do livro: ");
        livro.Titulo = Console.ReadLine();
        Console.WriteLine("Número de páginas (opcional): ");
        var tmp = Console.ReadLine().Trim();
        if (tmp != "")
            livro.Paginas = Convert.ToInt32(tmp);
        Console.WriteLine("Escolha o autor: ");
        OperacoesAutor.ListarComChave();
        var autorid = Convert.ToInt32(Console.ReadLine());
        var autor = db.Autor.First(p => p.AutorID == autorid);
        livro.Autor = autor;
        db.Livro.Add(livro);
        db.SaveChanges();
        Console.WriteLine("Livro adicionado com sucesso!");
    }

    public static void Listar()
    {
        var db = new AplicacaoDbContext();
        var livros = db.Livro
            .Include(p => p.Autor)
            .ThenInclude(p => p.Endereco);
        Console.WriteLine("ISBN - Título - Páginas - Autor - UFdoAutor - Gênero");
        foreach (var livro in livros)
        {
            Console.WriteLine($"{livro.ISBN}, {livro.Titulo}, " +
                              $"{livro.Paginas}, {livro.Autor.Nome}, " +
                              $"{livro.Autor.Endereco.UF}");
        }
    }

    public static void Alterar()
    {
        using var db = new AplicacaoDbContext();
        Console.WriteLine("Selecione o número do livro a partir da lista");
        OperacoesLivro.Listar();
        var livroid = Console.ReadLine();
        var livro = db.Livro.Find(livroid);
        if (livro == null)
        {
            Console.WriteLine("Selecione um livro da lista!");
            return;
        }
        string t;
        Console.WriteLine($"Título do livro: {livro.Titulo}");
        t = Console.ReadLine().Trim();
        if (t != "")
        {
            livro.Titulo = t;
        }
        Console.WriteLine("Número de páginas (opcional): ");
        t = Console.ReadLine().Trim();
        if (t != "")
        {
            livro.Paginas = Convert.ToInt32(t);
        }

        db.SaveChanges();
    }

    public static void Remover()
    {
        using var db = new AplicacaoDbContext();
        Console.WriteLine("Selecione o número do livro a partir da lista");
        OperacoesLivro.Listar();
        var livroid = Console.ReadLine();
        var livro = db.Livro.Find(livroid);
        if (livro == null)
        {
            Console.WriteLine("Selecione um livro da lista!");
            return;
        }
        db.Livro.Remove(livro);
        db.SaveChanges();
    }
}