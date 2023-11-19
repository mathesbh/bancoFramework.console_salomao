using Domain.Interfaces;
using Domain.Model;

namespace Application.Services
{
    public class MenuServices : IMenuServices
    {
        public MenuServices()
        {

        }
        public void OpcoesMenu(Cliente cliente)
        {
            string opcao;
            do
            {
                opcao = Menu(cliente);
            } while (opcao == "X");
        }

        private string Menu(Cliente cliente)
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

        private void Depositar(Cliente cliente)
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

        private void Sacar(Cliente cliente)
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

        private void Sair()
        {
            Console.WriteLine("Até logo");
        }
    }
}
