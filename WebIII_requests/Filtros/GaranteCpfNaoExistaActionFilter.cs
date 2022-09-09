using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebIII_requests.Core.Interface;
using WebIII_requests.Core.Model;

namespace WebIII_requests.Filtros
{
    public class GaranteCpfNaoExistaActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public GaranteCpfNaoExistaActionFilter (IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Clientes cliente = (Clientes)context.ActionArguments["cliente"];
            if (_clienteService.ConsultarClientePorCpf(cliente.Cpf) != null) 
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
