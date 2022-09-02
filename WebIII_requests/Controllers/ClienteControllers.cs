using Microsoft.AspNetCore.Mvc;
using WebIII_requests.Repository;
using WebIII_requests.Services;

namespace WebIII_requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        public ClienteRepository _repositoryCliente;

        public ClientesController(IConfiguration configuration)
        {
            
            var repositoryProduto = new ClienteRepository(configuration);
        }

        [HttpGet("/ Cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Clientes>> GetCliente()
        {
            return Ok(_repositoryCliente.GetCliente());
        }

        [HttpPost("/ Cliente/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Clientes> AdicionarCliente(Clientes NovoCliente)
        {
           if (!_repositoryCliente.InsertCliente(NovoCliente))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(AdicionarCliente), NovoCliente); ;
        }

        [HttpPut("/ Cliente/atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AlterarCliente(string cpf, Clientes cliente )
        {
            if (!_repositoryCliente.UpdateCliente(cpf, cliente))
            {
                return BadRequest();
            }
            return Ok (_repositoryCliente.UpdateCliente(cpf, cliente));
        }

        [HttpDelete("/ Cliente/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        public ActionResult<List<Clientes>> RemoverCliente(string cpf)
        {
            if (!_repositoryCliente.DeleteCliente(cpf))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
