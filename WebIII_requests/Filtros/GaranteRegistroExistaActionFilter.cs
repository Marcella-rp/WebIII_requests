using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WebIII_requests.Core.Interface;
using WebIII_requests.Core.Model;

namespace WebIII_requests.Filtros
{
    public class GaranteRegistroExistaActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public GaranteRegistroExistaActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long id = (long)context.ActionArguments["id"];

            if (_clienteService.ConsultarClientePorId == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
