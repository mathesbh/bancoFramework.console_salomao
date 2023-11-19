using Application.Services;
using Domain.Interfaces;
using Repository;

internal class Program
{
    private static IClienteRepository _clienteRepository = new ClienteRepository();
    private static IMenuServices _menuServices = new MenuServices(_clienteRepository);
    private static IClienteServices _clienteServices = new ClienteServices(_clienteRepository);
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = _clienteServices.IdentificacoAsync().Result;

        _menuServices.OpcoesMenu(cliente);
    }
}