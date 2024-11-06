using System.Globalization;
using EF.Exemplo6;
using Microsoft.EntityFrameworkCore;

public static class OperacoesAutor
{
    public static void Incluir()
    {
        using var db = new AplicacaoDbContext();
        var autor = new Autor();
        Console.Write("Nome do autor: ");
        autor.Nome = Console.ReadLine();
        Console.Write("Data de nascimento (yyyy-mm-dd): ");
        autor.DataNascimento = DateOnly.
            ParseExact(Console.ReadLine(),
                "yyyy-MM-dd", CultureInfo.InvariantCulture);

        var endereco = new Endereco();
        Console.Write("Logradouro: ");
        endereco.Logradouro = Console.ReadLine();
        Console.Write("Cidade: ");
        endereco.Cidade = Console.ReadLine();
        Console.Write("UF: ");
        endereco.UF = Console.ReadLine();
        Console.Write("CEP: ");
        endereco.CEP = Console.ReadLine();
        
        autor.Endereco = endereco;
        db.Autor.Add(autor);
        db.Endereco.Add(endereco);
        db.SaveChanges();
        Console.WriteLine("Autor adicionado com sucesso!");
    }

    public static void Listar()
    {
        using var db = new AplicacaoDbContext();
        // desligando acompanhamento de objetos NA CONSULTA
        // Eager loading de propriedades relacionadas
        var autores = db.Autor
            .AsNoTracking().
            Include(p => p.Endereco);
        Console.WriteLine("Nome - Data de Nascimento - Endereço");
        foreach (var autor in autores)
        {
            Console.WriteLine($"{autor.Nome} - {autor.DataNascimento.ToString()} -" +
                              $" {autor.Endereco.Logradouro} - {autor.Endereco.Cidade} -" +
                              $" ({autor.Endereco.UF}) - {autor.Endereco.CEP}");
        }
    }
    public static void ListarComChave()
    {
        using var db = new AplicacaoDbContext();
        // desligando o acompanhamento de objetos NO CONTEXTO
        // Mudanças não serão gravadas
        db.ChangeTracker.QueryTrackingBehavior 
            = QueryTrackingBehavior.NoTracking;
        var autores = db.Autor.
            Include(p => p.Endereco);
        Console.WriteLine("ID - Nome");
        foreach (var autor in autores)
        {
            Console.WriteLine($"{autor.AutorID} - {autor.Nome}");
        }
    }
    
    // public static void ListarExplict()
    // {
    //     using var db = new AplicacaoDbContext();
    //     // desligando acompanhamento de objetos NA CONSULTA
    //     // Explicit loading de propriedades relacionadas
    //     var autores = db.Autor.ToList();
    //     Console.WriteLine("Nome, DataNascimento, Endereço");
    //     foreach (var autor in autores)
    //     {
    //         // Se a entidade Endereco associada à entidade Autor atual
    //         // não estiver carregada...
    //         if (!db.Entry(autor).Reference(p  => p.Endereco).IsLoaded)
    //             // Faça a carga dela...
    //             db.Entry(autor).Reference(p => p.Endereco).Load();
    //         Console.WriteLine($"{autor.Nome}, {autor.DataNascimento.ToString()}," +
    //                           $" {autor.Endereco.Logradouro}, {autor.Endereco.Cidade} " +
    //                           $"({autor.Endereco.UF}), {autor.Endereco.CEP}");
    //     }
    // }
    // public static void ListarLazy()
    // {
    //     using var db = new AplicacaoDbContext();
    //     // desligando acompanhamento de objetos NA CONSULTA
    //     // Lazy loading de propriedades relacionadas
    //     var autores = db.Autor.ToList();
    //     Console.WriteLine("Nome, DataNascimento, Endereço");
    //     foreach (var autor in autores)
    //     {
    //         Console.WriteLine($"{autor.Nome}, {autor.DataNascimento.ToString()}," +
    //                           $" {autor.Endereco.Logradouro}, {autor.Endereco.Cidade} " +
    //                           $"({autor.Endereco.UF}), {autor.Endereco.CEP}");
    //     }
    // }


    public static void Alterar()
    {
        using var db = new AplicacaoDbContext();
        Console.WriteLine("Selecione o número do autor a partir da lista");
        OperacoesAutor.ListarComChave();
        var autorid = Convert.ToInt32(Console.ReadLine());
        //var autor = db.Autor.FirstOrDefault(p => p.AutorID == autorid);
        var autor = db.Autor.Find(autorid);
        // var autor = db.Autor
        //     .Where(p => p.AutorID == autorid)
        //     .Include(p => p.Endereco);
        if (autor == null)
        {
            Console.WriteLine("Selecione um autor da lista!");
            return;
        }

        string t;
        Console.WriteLine($"Nome do autor: {autor.Nome}");
        t = Console.ReadLine().Trim();
        if (t != "")
        {
            autor.Nome = t;
        }
        Console.WriteLine($"Data de nascimento (yyyy-mm-dd): {autor.DataNascimento}");
        t = Console.ReadLine().Trim();
        if (t != "")
        {
            autor.DataNascimento = DateOnly.ParseExact(t,
                "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        // var endereco = new Endereco();
        // Console.Write("Logradouro: ");
        // endereco.Logradouro = Console.ReadLine();
        // Console.Write("Cidade: ");
        // endereco.Cidade = Console.ReadLine();
        // Console.Write("UF: ");
        // endereco.UF = Console.ReadLine();
        // Console.Write("CEP: ");
        // endereco.CEP = Console.ReadLine();
        db.SaveChanges();
        Console.WriteLine("Autor alterado com sucesso!");
    }

    public static void Remover()
    {
        using var db = new AplicacaoDbContext();
        Console.WriteLine("Selecione o número do autor a partir da lista");
        OperacoesAutor.ListarComChave();
        var autorid = Convert.ToInt32(Console.ReadLine());
        var autor = db.Autor.Find(autorid);
        if (autor == null)
        {
            Console.WriteLine("Selecione um autor da lista!");
            return;
        }

        db.Autor.Remove(autor);
        db.SaveChanges();
        Console.WriteLine("Autor removido com sucesso!");
    }
}