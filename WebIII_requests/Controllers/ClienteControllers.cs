using Microsoft.AspNetCore.Mvc;
using WebIII_requests.Core.Interface;
using WebIII_requests.Core.Model;

namespace WebIII_requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        public IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("/ Cliente/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Clientes>> ConsultarClientes()
        {
            return Ok(_clienteService.ConsultarClientes());
        }

        [HttpPost("/ Cliente/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Clientes> AdicionarCliente(Clientes NovoCliente)
        {
           if (!_clienteService.InserirCliente(NovoCliente))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(AdicionarCliente), NovoCliente); ;
        }

        [HttpPut("/ Cliente/atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AlterarCliente(long id, Clientes cliente )
        {
            if (!_clienteService.AtualizarCliente(id, cliente))
            {
                return NotFound();
            }
            return Ok (_clienteService.AtualizarCliente(id, cliente));
        }

        [HttpDelete("/ Cliente/deletar")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        public ActionResult<List<Clientes>> RemoverCliente(long id)
        {
            if (!_clienteService.DeletarCliente(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
