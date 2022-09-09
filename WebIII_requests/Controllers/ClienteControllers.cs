using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebIII_requests.Core.Interface;
using WebIII_requests.Core.Model;
using WebIII_requests.Filtros;

namespace WebIII_requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogTempoExecucaoResourceFilter))]
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

        [HttpGet("/ Cliente/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
   
        public ActionResult<Clientes> ConsultarClientePorCpf(string cpf)
        {
            if (_clienteService.ConsultarClientePorCpf(cpf) == null)
            {
                return NotFound();
            }
            return Ok(_clienteService.ConsultarClientePorCpf(cpf));
        }

        [HttpGet("/ Cliente/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Clientes> ConsultarClientePorIpf(long id)
        {
            if (_clienteService.ConsultarClientePorId(id) == null)
            {
                return NotFound();
            }
            return Ok(_clienteService.ConsultarClientePorId(id));
        }

        [HttpPost("/ Cliente/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [TypeFilter(typeof(GaranteCpfNaoExistaActionFilter))]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [TypeFilter(typeof(GaranteRegistroExistaActionFilter))]
        public IActionResult AlterarCliente(long id, Clientes cliente )
        {
            if (!_clienteService.AtualizarCliente(id, cliente))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
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
