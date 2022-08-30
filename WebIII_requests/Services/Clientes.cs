namespace WebIII_requests.Services
{
    public class Clientes
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }

        public Clientes(string cpf, string nome, DateTime datanascimento)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = datanascimento;
        }

        public int ObterIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }

    }
    
}
