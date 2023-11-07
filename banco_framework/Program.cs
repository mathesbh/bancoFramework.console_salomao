using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var pessoa = Identificacao();

        OpcoesMenu();
    }

    static void OpcoesMenu()
    {
        string opcao;
        do
        {
            opcao = Menu();
        } while (opcao == "X");
    }

    static Pessoa Identificacao()
    {
        var pessoa = new Cliente();

        Console.WriteLine("Seu número de identificação:");
        pessoa.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        pessoa.Cpf = Console.ReadLine();

        Console.WriteLine("Seu saldo:");
        pessoa.Saldo = double.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine($"Como posso ajudar {pessoa.Nome}?");

        return pessoa;
    }

    static string Menu()
    {
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.WriteLine("3 - Sair");
        Console.WriteLine("------------");
        Console.WriteLine("Selecione uma opção");

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Depositar();
                break;
            case "2":
                Sacar();
                break;
            case "3":
                Sair();
                break;
            default:
                return "X";
        }

        return opcao;
    }

    static void Depositar()
    {
        Console.WriteLine("Deposito");
        Console.ReadKey();
    }

    static void Sacar()
    {
        Console.WriteLine("Saque");
        Console.ReadKey();
    }

    static void Sair()
    {
        Console.WriteLine("Até logo");
    }
}