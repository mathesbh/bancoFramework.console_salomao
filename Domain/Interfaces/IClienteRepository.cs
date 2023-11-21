using Domain.Model;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> BuscarClientePorIdAsync(int id);
        Task CadastrarClienteAsync(Cliente cliente);
        Task AtualizarClienteAsync(Cliente cliente);
    }
}
