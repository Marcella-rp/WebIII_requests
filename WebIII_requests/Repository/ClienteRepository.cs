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

        public bool UpdateCliente(string cpf, Clientes cliente)
        {
            var query = @"UPDATE clientes set nome = @nome,
                        datadenascimento = @datadenascimento, idade = @idade
                        WHERE cpf = @cpf";

            cliente.Cpf = cpf;

            var parameters = new DynamicParameters(cliente);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCliente(string cpf)
        {
            var query = "DELETE FROM clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;

        }

    }
}
