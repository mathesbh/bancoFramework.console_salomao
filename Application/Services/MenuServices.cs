using Domain.Interfaces;
using Domain.Model;

namespace Application.Services
{
    public class MenuServices : IMenuServices
    {
        private readonly IClienteServices _clienteServices;
        private readonly IClienteRepository _clienteRepository;
        public MenuServices(IClienteRepository clienteRepository, IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
            _clienteRepository = clienteRepository;
        }

        public async Task BoasVindas()
        {
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao banco Framework");
            Console.WriteLine("Por favor, identifique-se");
            Console.WriteLine("");

            var cliente = await _clienteServices.IdentificacoAsync();

            OpcoesMenu(cliente);
        }

        private void OpcoesMenu(Cliente cliente)
        {
            string opcao;
            do
            {
                opcao = Menu(cliente).Result;
            } while (opcao == "X");
        }

        private async Task<string> Menu(Cliente cliente)
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
                    await DepositarAsync(cliente);
                    break;
                case "2":
                    await SacarAsync(cliente);
                    break;
                case "3":
                    Sair();
                    break;
                default:
                    return "X";
            }

            return opcao;
        }

        private async Task DepositarAsync(Cliente cliente)
        {
            Console.WriteLine("Deposito");
            Console.Clear();
            Console.WriteLine("Digite o valor: ");
            var valor = float.Parse(Console.ReadLine());

            cliente.SetSaldo(Calculo.Soma((float)cliente.Saldo, valor));
            await _clienteRepository.AtualizarClienteAsync(cliente);

            Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
            Console.WriteLine();

            OpcoesMenu(cliente);
        }

        private async Task SacarAsync(Cliente cliente)
        {
            Console.WriteLine("Saque");
            Console.Clear();
            Console.WriteLine("Digite o valor: ");
            var valor = float.Parse(Console.ReadLine());

            cliente.SetSaldo(Calculo.Subtracao((float)cliente.Saldo, valor));
            await _clienteRepository.AtualizarClienteAsync(cliente);

            Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
            Console.WriteLine();

            OpcoesMenu(cliente);
        }

        private void Sair()
        {
            Console.WriteLine("Até logo");
        }
    }
}
