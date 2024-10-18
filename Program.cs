using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EF.Exemplo6;

while (true)
{
    Console.WriteLine("======== Menu");
    Console.WriteLine("11. Cadastrar autor");
    Console.WriteLine("12. Alterar autor");
    Console.WriteLine("13. Remover autor");
    Console.WriteLine("14. Listar autores");
    Console.WriteLine("21. Cadastrar livro");
    Console.WriteLine("22. Alterar livro");
    Console.WriteLine("23. Remover livro");
    Console.WriteLine("24. Listar livros");
    Console.WriteLine("31. Cadastrar gênero");
    Console.WriteLine("32. Vincular gênero");
    Console.WriteLine("33. Alterar gênero");
    Console.WriteLine("34. Remover gênero");
    Console.WriteLine("35. Listar gêneros");
    Console.WriteLine("41. Vender livro(s)");
    Console.WriteLine("42. Comprar livro(s)");
    Console.WriteLine("0. Sair");
    Console.Write("Digite sua opção: ");
    var opcao = Console.ReadLine().Trim();
    switch (opcao)
    {
        case "11": // Incluir autor
            OperacoesAutor.Incluir();
            break;
        case "12": // Alterar autor
            OperacoesAutor.Alterar();
            break;
        case "13": // Remover autor
            OperacoesAutor.Remover();
            break;
        case "14": // Listar autores
            OperacoesAutor.Listar();
            break;
        case "21": // Incluir livro
            OperacoesLivro.Incluir();
            break;
        case "22": // Alterar livro
            OperacoesLivro.Alterar();
            break;
        case "23": // Remover livro
            OperacoesLivro.Remover();
            break;
        case "24": // Listar livros
            OperacoesLivro.Listar();
            break;
        case "31": // Adicionar gênero
            OperacoesGenero.Adicionar();
            break;
        case "32": // Incluir gênero ao livro
            OperacoesLivroGenero.Incluir();
            break;
        case "33": // Alterar gênero
            OperacoesGenero.Alterar();
            break;
        case "34": // Remover gênero
            OperacoesGenero.Remover();
            break;
        case "35": // Listar gêneros
            OperacoesGenero.Listar();
            break;
        case "41": // Vender livro(s)
            OperacoesLivro.Vender();
            break;
        case "42": // Comprar livro(s)
            OperacoesLivro.Comprar();
            break;
        case "0":
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
    if (opcao == "0") break;
}

Console.WriteLine("Aplicação finalizada");