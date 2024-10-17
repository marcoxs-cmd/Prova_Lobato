namespace EF.Exemplo6;

public class OperacoesLivroGenero
{
    public static void Incluir()
    {
        using var db = new AplicacaoDbContext();
        var livrogenero = new LivroGenero();
        Console.WriteLine("Selecione o número do gênero a partir da lista");
        OperacoesGenero.Listar();
        var generoid = Convert.ToInt32(Console.ReadLine());
        var genero = db.Genero.Find(generoid);
        if (genero == null) 
        {
            Console.WriteLine("Selecione um gênero da lista!");
            return;
        }
        livrogenero.Genero = genero;
        Console.WriteLine("Selecione o número do livro a partir da lista");
        OperacoesLivro.Listar();
        var livroid = Console.ReadLine();
        var livro = db.Livro.Find(livroid);
        if (livro == null)
        {
            Console.WriteLine("Selecione um livro da lista!");
            return;
        }
        livrogenero.Livro = livro;
        db.LivroGenero.Add(livrogenero);
        db.SaveChanges();
        Console.WriteLine("Livro adicionado com sucesso!");
        
    }
}