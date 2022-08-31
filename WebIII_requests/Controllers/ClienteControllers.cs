using Microsoft.AspNetCore.Mvc;
using WebIII_requests.Services;

namespace WebIII_requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {

        [HttpGet("/ Cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Clientes>> GetCliente()
        {
            return Ok (ListaDeClientes.listaDeClientes);
        }

        [HttpPost("/ Cliente/cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public ActionResult<Clientes> AdicionarCliente(Clientes NovoCliente)
        {
            ListaDeClientes.listaDeClientes.Add(NovoCliente);
            return Ok(NovoCliente);
        }

        [HttpPut("/ Cliente/atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Clientes>> AlterarCliente(string cpf, string nome)
        {
            var listateste = ListaDeClientes.listaDeClientes.Where(c => c.Cpf == cpf).ToList();
            if (!(listateste.Exists(c => c.Cpf == cpf)))
            {
                return NotFound();
            }
            else
            {
                foreach (var cliente in ListaDeClientes.listaDeClientes)
                {
                    cliente.Nome = nome;
                }
            }
            return Ok (ListaDeClientes.listaDeClientes);
        }

        [HttpDelete("/ Cliente/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        public ActionResult<List<Clientes>> RemoverCliente(string cpf)
        {
            var query = ListaDeClientes.listaDeClientes.Where(c => c.Cpf == cpf).ToList();
            return ListaDeClientes.listaDeClientes;
            if(!(query.Exists(c => c.Cpf == cpf)))
            {
                return NotFound();
            }
            ListaDeClientes.listaDeClientes.RemoveAll(c => c.Cpf == cpf);
            return NoContent();
        }
    }
}
