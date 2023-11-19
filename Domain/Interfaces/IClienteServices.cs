using Domain.Model;

namespace Domain.Interfaces
{
    public interface IClienteServices
    {
        Task<Cliente> IdentificacoAsync();
    }
}
