using Application;
using Application.Services;
using Domain.Interfaces;
using Domain.Model;

internal class Program
{
    private static IClienteServices _clienteServices = new ClienteServices();
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = _clienteServices.IdentificacoAsync().Result;

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
        
        cliente.SetSaldo(Calculo.Soma((float)cliente.Saldo, valor));
        
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

        cliente.SetSaldo(Calculo.Subtracao((float)cliente.Saldo, valor));

        Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
        Console.WriteLine();

        OpcoesMenu(cliente);
    }

    static void Sair()
    {
        Console.WriteLine("Até logo");
    }
}