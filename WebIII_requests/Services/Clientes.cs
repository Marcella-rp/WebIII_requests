using System.ComponentModel.DataAnnotations;

namespace WebIII_requests.Services
{
    public class Clientes
    {
        [Required(ErrorMessage = "CPF é obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF deve conter até 11 caracteres")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
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
