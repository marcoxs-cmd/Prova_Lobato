using System.Globalization;
using EF.Exemplo6;
using Microsoft.EntityFrameworkCore;


public class OperacoesGenero
{
    public static void Adicionar()
    {
        using var db = new AplicacaoDbContext();
        var genero = new Genero();
        Console.WriteLine("Gênero: ");
        genero.Nome = Console.ReadLine();
        db.Genero.Add(genero);
        db.SaveChanges();
        Console.WriteLine("Gênero adicionado com sucesso!");
    }

    public static void Alterar()
    {
        using var db = new AplicacaoDbContext();
        Console.WriteLine("Selecione o número do gênero a partir da lista");
        OperacoesGenero.Listar();
        var generoid = Convert.ToInt32(Console.ReadLine());
        var genero = db.Genero.Find(generoid);
        if (genero == null)
        {
            Console.WriteLine("Selecione um gênero da lista!");
            return;
        }
        string t;
        Console.WriteLine($"Título do livro: {genero.Nome}");
        t = Console.ReadLine().Trim();
        if (t != "")
        {
            genero.Nome = t;
        }
        db.SaveChanges();
    }

    public static void Listar()
    {
        using var db = new AplicacaoDbContext();
        var generos = db.Genero;
        Console.WriteLine("ID - Nome");
        foreach (var genero in generos)
        {
            Console.WriteLine($"{genero.GeneroID}, {genero.Nome}");
        }
    }

    public static void Remover()
    {
        using var db = new AplicacaoDbContext();
        Console.WriteLine("Selecione o número do gênero a partir da lista");
        OperacoesGenero.Listar();
        var generoid = Convert.ToInt32(Console.ReadLine());
        var genero = db.Genero.Find(generoid);
        if (genero == null)
        {
            Console.WriteLine("Selecione um gênero da lista!");
            return;
        }
        db.Genero.Remove(genero);
        db.SaveChanges();
    }

    public static void ListarC()
    {
        using var db = new AplicacaoDbContext();
        var disf = db.LivroGenero.
            Include(p => p.Livro);
        Console.WriteLine("Genero - Livro");
        foreach (var dif in disf)
        {
            Console.WriteLine($"{dif.Genero}, {dif.Livro}");
        }
    }
}