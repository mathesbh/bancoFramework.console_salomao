using Dapper;
using Domain.Interfaces;
using Domain.Model;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private const string CONNECTION = "Server=127.0.0.1,1433;Database=bancoFramework;User ID=sa;Password=1q2w3e4r@#$";
        public ClienteRepository()
        {

        }

        public async Task<Cliente> BuscaClientePorIdAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(CONNECTION))
            {
                Cliente cliente;
                try
                {
                    db.Open();
                    var result = await db.QuerySingleOrDefaultAsync<Cliente>("SELECT * FROM [Clientes] (NOLOCK) WHERE [ID] = @id", new { id });
                    cliente = result;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

                return cliente;
            }
        }

        public async Task CadastrarClienteAsync(Cliente cliente)
        {
            using (IDbConnection db = new SqlConnection(CONNECTION))
            {
                try
                {
                    db.Open();
                    await db.ExecuteAsync("INSERT INTO [Clientes] ([ID], [NOME], [CPF], [SALDO]) VALUES (@Id, @Nome, @Cpf, @Saldo)", cliente);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            using (IDbConnection db = new SqlConnection(CONNECTION))
            {
                try
                {
                    db.Open();
                    await db.ExecuteAsync("UPDATE [Clientes] SET [Nome] = @Nome, [Cpf] = @Cpf, [Saldo] = @Saldo WHERE [ID] = @Id", cliente);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
    }
}
