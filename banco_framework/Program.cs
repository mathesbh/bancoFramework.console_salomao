using Application;
using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = Identificacao();

        OpcoesMenu(cliente);
    }

    static void OpcoesMenu(Cliente cliente)
    {
        string opcao;
        do
        {
            opcao = Menu(cliente);
        } while (opcao == "X");
    }

    static Cliente Identificacao()
    {
        var cliente = new Cliente();

        Console.WriteLine("Seu número de identificação:");
        cliente.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        cliente.Cpf = Console.ReadLine();

        Console.WriteLine("Seu saldo:");
        cliente.Saldo = double.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine($"Como posso ajudar {cliente.Nome}?");

        return cliente;
    }

    static string Menu(Cliente cliente)
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
                Depositar(cliente);
                break;
            case "2":
                Sacar(cliente);
                break;
            case "3":
                Sair();
                break;
            default:
                return "X";
        }

        return opcao;
    }

    static void Depositar(Cliente cliente)
    {
        Console.WriteLine("Deposito");
        Console.Clear();
        Console.WriteLine("Digite o valor: ");
        var valor = float.Parse(Console.ReadLine());
        
        var calc = new Calculo();
        cliente.Saldo = calc.Soma((float)cliente.Saldo, valor);
        
        Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
        Console.WriteLine();
        
        OpcoesMenu(cliente);
    }

    static void Sacar(Cliente cliente)
    {
        Console.WriteLine("Saque");
        Console.Clear();
        Console.WriteLine("Digite o valor: ");
        var valor = float.Parse(Console.ReadLine());

        var calc = new Calculo();
        cliente.Saldo = calc.Subtracao((float)cliente.Saldo, valor);

        Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
        Console.WriteLine();

        OpcoesMenu(cliente);
    }

    static void Sair()
    {
        Console.WriteLine("Até logo");
    }
}