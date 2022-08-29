namespace WebIII_requests.Services
{
    public static class ListaDeAlunos
    {
        public static List<Alunos> listaDeAlunos = new List<Alunos>()
        {
            new Alunos("962.397.190-72", "Ana Julia Coelho", "Marta Maria Coelho", "6A",new DateTime(2009, 08,08)),
            new Alunos("962.397.190-72", "Luiz Henrique Martinz","Mauricio Martinz","6B", new DateTime(2009,03,10)),
            new Alunos("890.403.430-20", "Manuela Pereira", "Victor Pereira", "6C", new DateTime (2009,06,16))
        };
    }
}
