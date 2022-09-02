using Dapper;
using Microsoft.Data.SqlClient;
using WebIII_requests.Services;

namespace WebIII_requests.Repository
{
    public class ClienteRepository
    {

        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Clientes> GetCliente()
        {
            var query = "SELECT * FROM Clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Clientes>(query).ToList(); 
        }

        public bool InsertCliente(Clientes cliente)
        {
            var query = $"INSERT INTO clientes VALUES(@cpf,@nome,@datanascimento,@idade)";

            var parameters = new DynamicParameters(new
            {
                cliente.Cpf,
                cliente.Nome,
                cliente.DataNascimento,
                cliente.Idade
            });

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateCliente(long id, Clientes cliente)
        {
            var query = @"UPDATE clientes set cpf = @cpf, nome = @nome,
                        dataNascimento = @dataNascimento 
                        WHERE id = @id";

            cliente.Id = id;

            var parameters = new DynamicParameters(cliente);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCliente(long id)
        {
            var query = "DELETE FROM clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;

        }

    }
}
