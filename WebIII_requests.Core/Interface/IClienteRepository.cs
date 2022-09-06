using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebIII_requests.Core.Model;


namespace WebIII_requests.Core.Interface
{
    public interface IClienteRepository
    {
        List<Clientes> ConsultarClientes();
        bool InserirCliente(Clientes cliente);
        bool AtualizarCliente(long id, Clientes cliente);
        bool DeletarCliente(long id);
    }
}
