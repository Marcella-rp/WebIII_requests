using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebIII_requests.Core.Interface;
using WebIII_requests.Core.Model;

namespace WebIII_requests.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository 
    {

        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Clientes> ConsultarClientes()
        {
            var query = "SELECT * FROM Clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Clientes>(query).ToList(); 
        }

        public bool InserirCliente(Clientes cliente)
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

        public bool AtualizarCliente(long id, Clientes cliente)
        {
            var query = @"UPDATE clientes set cpf = @cpf, nome = @nome,
                        dataNascimento = @dataNascimento 
                        WHERE id = @id";

            cliente.Id = id;

            var parameters = new DynamicParameters(cliente);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeletarCliente(long id)
        {
            var query = "DELETE FROM clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;

        }

        public Clientes ConsultarClientePorCpf(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE cpf=@cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf",cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Clientes>(query,parameters);

        }

        public Clientes ConsultarClientePorId(long id)
        {
            var query = "SELECT * FROM Clientes WHERE id=@id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Clientes>(query, parameters);

        }
    }
}
