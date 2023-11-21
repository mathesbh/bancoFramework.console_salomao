using Dapper;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string? _connection;
        public ClienteRepository()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();

            _connection = config["ConnectionString:SqlServer"];

        }

        public async Task<Cliente> BuscarClientePorIdAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connection))
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
            using (IDbConnection db = new SqlConnection(_connection))
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

        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            using (IDbConnection db = new SqlConnection(_connection))
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
