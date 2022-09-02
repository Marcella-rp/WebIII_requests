using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace WebIII_requests.Services
{
    public class Clientes
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF deve conter até 11 caracteres")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }
        [Range (18, int.MaxValue, ErrorMessage = "Cliente precisa ser maior que 18 anos")]
        public int Idade => ObterIdade();

        
        public int ObterIdade()
        {
            int idade = (int)(DateTime.Today - DataNascimento).TotalDays;
            idade = idade / 365;
            return idade;
        }

    }
    
}
