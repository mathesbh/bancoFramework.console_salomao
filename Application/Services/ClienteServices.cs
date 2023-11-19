using Domain.Interfaces;
using Domain.Model;
using CpfCnpjLibrary;

namespace Application.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> IdentificacoAsync()
        {
            Cliente cliente = null!;
            var erros = new List<string>();

            Console.WriteLine("Seu número de identificação:");
            var inputId = int.TryParse(Console.ReadLine(), out var id);
            if (!inputId)
                erros.Add("Identificador não é válido");

            cliente = await _clienteRepository.BuscaClientePorIdAsync(id);
            if (cliente is not null)
            {
                MensagemComoPossoAjudar(cliente.Nome);
                return cliente;
            }

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

            cliente = new Cliente(id, inputNome, inputCPF, saldo);
            await _clienteRepository.CadastrarClienteAsync(cliente);
            MensagemComoPossoAjudar(cliente.Nome);

            return cliente;
        }

        private void MensagemComoPossoAjudar(string nome)
            => Console.WriteLine($"Como posso ajudar {nome}?");
    }
}
