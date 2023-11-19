using Application.Services;
using Domain.Interfaces;

internal class Program
{
    private static IMenuServices _menuServices = new MenuServices();
    private static IClienteServices _clienteServices = new ClienteServices();
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