using Microsoft.AspNetCore.Mvc;
using WebIII_requests.Services;

namespace WebIII_requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {

        [HttpGet]
        public List<Clientes> GetCliente()
        {
            return ListaDeClientes.listaDeClientes;
        }

        [HttpPost]
        public Clientes AdicionarCliente(Clientes NovoCliente)
        {
            ListaDeClientes.listaDeClientes.Add(NovoCliente);
            return NovoCliente;
        }

        [HttpPut]
        public List<Clientes> AlterarCliente(string cpf, string nome)
        {
            var listateste = ListaDeClientes.listaDeClientes.Where(c => c.Cpf == cpf).ToList();
            if (listateste.Exists(c => c.Cpf == cpf))
            {
                foreach (var cliente in ListaDeClientes.listaDeClientes)
                {
                    cliente.Nome = nome;
                }
            }
            return ListaDeClientes.listaDeClientes;
        }

        [HttpDelete]
        public List<Clientes> RemoverCliente(string cpf)
        {
            ListaDeClientes.listaDeClientes.RemoveAll(c => c.Cpf == cpf);
            return ListaDeClientes.listaDeClientes;
        }
    }
}
