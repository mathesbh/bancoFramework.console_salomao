using Domain.Model;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> BuscaClientePorIdAsync(int id);
        Task CadastrarClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
    }
}
