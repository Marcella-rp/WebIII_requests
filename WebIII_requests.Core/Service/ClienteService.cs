using WebIII_requests.Core.Interface;
using WebIII_requests.Core.Model;

namespace WebIII_requests.Core.Service //aqui tudo que é cerne do sistema.Onde esta o controle, a regra de negocio.
{
    public class ClienteService : IClienteService
    {
        public IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public List<Clientes> ConsultarClientes()
        {
            return _clienteRepository.ConsultarClientes();
        }
        public bool InserirCliente (Clientes cliente)
        {
            return _clienteRepository.InserirCliente(cliente);
        }
        public bool AtualizarCliente (long id, Clientes cliente)
        {
            return _clienteRepository.AtualizarCliente(id, cliente);
        }
        public bool DeletarCliente(long id)
        {
            return _clienteRepository.DeletarCliente(id);
        }
    }
}