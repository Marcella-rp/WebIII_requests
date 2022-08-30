namespace WebIII_requests.Services
{
    public class ListaDeClientes
    {
        public static List<Clientes> listaDeClientes = new List<Clientes>()
        {
            new Clientes("962.397.190-72", "Ana Julia Coelho",new DateTime(2009, 08,08)),
            new Clientes("962.397.190-72", "Luiz Henrique Martinz", new DateTime(2009,03,10)),
            new Clientes("890.403.430-20", "Manuela Pereira", new DateTime (2009,06,16))
        };
    }
}
