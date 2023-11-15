using Application;
using CpfCnpjLibrary;
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
        var erros = new List<string>();

        Console.WriteLine("Seu número de identificação:");
        var inputId = int.TryParse(Console.ReadLine(), out var id);
        if (!inputId)
            erros.Add("Identificador não é válido");

        Console.WriteLine("Seu nome:");
        var inputNome = Console.ReadLine();
        if (string.IsNullOrEmpty(inputNome) || inputNome.Length <= 3)
            erros.Add("Nome digitado não é válido");

        Console.WriteLine("Seu CPF:");
        var inputCPF = Console.ReadLine();
        var validaCPF = Cpf.Validar(inputCPF);
        if (!validaCPF)
            erros.Add("CPF digitado não é válido");

        Console.WriteLine("Seu saldo:");
        var inputSaldo = double.TryParse(Console.ReadLine(),out var saldo);
        if(!inputSaldo || saldo <= 0)
            erros.Add("Saldo não é válido");

        if(erros.Any())
        {
            erros.ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
            Console.Clear();
            Identificacao();
        }

        Console.Clear();

        var cliente = new Cliente(id, inputNome, inputCPF, saldo);
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