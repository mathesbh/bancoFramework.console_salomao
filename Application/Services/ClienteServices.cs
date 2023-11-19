using Domain.Interfaces;
using Domain.Model;
using CpfCnpjLibrary;

namespace Application.Services
{
    public class ClienteServices : IClienteServices
    {
        public ClienteServices()
        {

        }

        public async Task<Cliente> IdentificacoAsync()
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
            var inputSaldo = double.TryParse(Console.ReadLine(), out var saldo);
            if (!inputSaldo || saldo <= 0)
                erros.Add("Saldo não é válido");

            if (erros.Any())
            {
                erros.ForEach(x => Console.WriteLine(x));
                Console.ReadKey();
                Console.Clear();
                await IdentificacoAsync();
            }

            Console.Clear();

            var cliente = new Cliente(id, inputNome, inputCPF, saldo);
            Console.WriteLine($"Como posso ajudar {cliente.Nome}?");

            return cliente;
        }
    }
}
