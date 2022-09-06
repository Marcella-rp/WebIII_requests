using WebIII_requests.Core.Model;

namespace WebIII_requests.Core.Interface
{
    public interface IClienteService
    {
        List<Clientes> ConsultarClientes();
        bool InserirCliente(Clientes cliente);
        bool AtualizarCliente(long id, Clientes cliente);
        bool DeletarCliente(long id);
    }
}
